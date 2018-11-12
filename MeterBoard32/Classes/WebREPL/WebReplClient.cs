using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using System.Text.RegularExpressions;
using static MeterBoard32.Classes.WebREPL.WebREPLEvents;

namespace MeterBoard32.Classes.WebREPL
{

    public class WebReplClient : WebSocket
    {

        public enum BinaryState
        {
            None, // None  
            First_Put_Response, // First response for put      
            Final_Put_Response, // Final response for put
            First_Get_Response, // First response for get
            File_Data, // File data
            Final_Response, // Final response
            Get_Version_Response // First (and last) response for GET_VER
        }     

        // WebSocket event handlers
        public event EventHandler OnConnected;
        public event EventHandler OnLoggedIn;
        public event EventHandler<CloseEventArgs> OnDisconnected;
        public event EventHandler<ErrorEventArgs> OnException;
        public event EventHandler<StringMessageEventArgs> OnMessageReceived;

        // MicroPython WebREPL command event handlers
        public event EventHandler<FileSentEventArgs> OnFileSent;
        public event EventHandler<FileReceivedEventArgs> OnFileReceived;
        public event EventHandler<VersionEventArgs> OnVersionReceived;
        public event EventHandler<AnsiEscapeCodeEventArgs> OnAnsiEventCodeReceived;
        public event EventHandler<FileDataReceivedEventArgs> OnFileDataReceived;

        private string password;
        private BinaryState currentBinaryState;

        private List<byte> fileDataToBeSent = new List<byte>();
        private List<byte> fileDataReceived = new List<byte>();
        private string fileNameOfFileToBeSent;
        private string fileNameOfFileReceived;
        private bool checkForError = false;
        private bool suppressMessage = false;

        private Regex escapeAnsiRegex = new Regex(@"\x1B\[[^@-~]*[@-~]");
        private Regex escapeBackspaceRegex = new Regex(@"\x08.");

        public WebReplClient(string host, int port, string password) : base(string.Format("ws://{0}:{1}", host, port))
        {
            // Store away password for later use
            this.password = password;

            // Set up event handlers for different WebSocket events
            OnMessage += Websocket_MessageReceived;
            OnOpen += Websocket_OnConnected;
            OnClose += Websocket_OnDisconnected;
            OnError += Websocket_OnError;
            CustomHeaders = new Dictionary<string, string>() {
                {"Sec-WebSocket-Extensions","permessage-deflate; client_max_window_bits"},
                {"Sec-WebSocket-Version", "13"},
                {"Accept-Encoding","gzip, deflate" },
                {"User-Agent", "MeterBoard32 Companion (Windows;1607;Desktop;ProcessName/AppName=MeterBoard32 Companion/1.0.0;DeviceType=Near)"},
            };

        }

        public void SendData(string data)
        {
            if (ReadyState.Equals(WebSocketState.Open))
            {
                Send(data);
                Console.WriteLine(String.Format("sent: {0}", BitConverter.ToString(Encoding.UTF8.GetBytes(data))));
            }
        }

        public void SendData(byte[] data)
        {
            if (ReadyState.Equals(WebSocketState.Open))
            {
                Send(data);
                Console.WriteLine(string.Format("sent: {0}", BitConverter.ToString(data)));
            }
        }

        public void SendFile(string fileName,byte[] fileData)
        {
            int destionationFileSize = fileData.Length;
            byte[] dataPacket = new byte[2 + 1 + 1 + 8 + 4 + 2 + 64];
            dataPacket[0] = (byte)'W';
            dataPacket[1] = (byte)'A';
            dataPacket[2] = 1; // put
            dataPacket[3] = 0;
            dataPacket[4] = 0; dataPacket[5] = 0; dataPacket[6] = 0; dataPacket[7] = 0; dataPacket[8] = 0; dataPacket[9] = 0; dataPacket[10] = 0; dataPacket[11] = 0;
            dataPacket[12] = (byte)(destionationFileSize & 0xff); dataPacket[13] = (byte)((destionationFileSize >> 8) & 0xff); dataPacket[14] = (byte)((destionationFileSize >> 16) & 0xff); dataPacket[15] = (byte)((destionationFileSize >> 24) & 0xff);
            dataPacket[16] = (byte)(fileName.Length & 0xff); dataPacket[17] = (byte)((fileName.Length >> 8) & 0xff);
            for (var i = 0; i < 64; ++i)
            {
                if (i < fileName.Length)
                {
                    dataPacket[18 + i] = (byte)fileName[i];
                }
                else
                {
                    dataPacket[18 + i] = 0;
                }
            }
            fileNameOfFileToBeSent = fileName;
            fileDataToBeSent.Clear();
            fileDataToBeSent.AddRange(fileData);
            currentBinaryState = BinaryState.First_Put_Response;
            SendData(dataPacket);
        }

        public void GetFile(string fileName)
        {
            // WEBREPL_FILE = "<2sBBQLH64s"
            byte[] dataPacket = new byte[2 + 1 + 1 + 8 + 4 + 2 + 64];
            dataPacket[0] = (byte)'W';
            dataPacket[1] = (byte)'A';
            dataPacket[2] = 2; // get
            dataPacket[3] = 0;
            dataPacket[4] = 0; dataPacket[5] = 0; dataPacket[6] = 0; dataPacket[7] = 0; dataPacket[8] = 0; dataPacket[9] = 0; dataPacket[10] = 0; dataPacket[11] = 0;
            dataPacket[12] = 0; dataPacket[13] = 0; dataPacket[14] = 0; dataPacket[15] = 0;
            dataPacket[16] = (byte)(fileName.Length & 0xff); dataPacket[17] = (byte)((fileName.Length >> 8) & 0xff);
            for (var i = 0; i < 64; ++i)
            {
                if (i < fileName.Length)
                {
                    dataPacket[18 + i] = (byte)fileName[i];
                }
                else
                {
                    dataPacket[18 + i] = 0;
                }
            }
            // initiate get
            fileDataReceived.Clear();
            fileNameOfFileReceived = fileName;
            currentBinaryState = BinaryState.First_Get_Response;
            SendData(dataPacket);
        }

        public void GetVersion()
        {
            byte[] dataPacket = new byte[2 + 1 + 1 + 8 + 4 + 2 + 64];
            dataPacket[0] = (byte)'W';
            dataPacket[1] = (byte)'A';
            dataPacket[2] = 3; // GET_VER
            // initiate GET_VER
            currentBinaryState = BinaryState.Get_Version_Response;
            SendData(dataPacket);
        }


        #region WebSocket event handlers
        
        /// <summary>
        /// Callback in the event of a successful WebSocket connection to a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Websocket_OnConnected(object sender, EventArgs e)
        {
            OnConnected.DynamicInvoke(this, e);
        }

        /// <summary>
        /// Callback in the event of a MeterBoard32 WebSocket having been disconnected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Websocket_OnDisconnected(object sender, CloseEventArgs e)
        {
            OnDisconnected.DynamicInvoke(this, e);
        }

        /// <summary>
        /// Callback in the event of an error with the MeterBoard32 WebSocket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Websocket_OnError(object sender, ErrorEventArgs e)
        {
            OnException.DynamicInvoke(this, e);
        }

        /// <summary>
        /// Callback in the event of incoming message data from a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Websocket_MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine(String.Format("received: {0}", BitConverter.ToString(e.RawData)));
            if (e.IsBinary)
            {
                HandleBinaryStates(e.RawData);
            }
            else
            {
                string message = e.Data;
                if (message == null)
                    return;

                if (message.StartsWith("Password:"))
                {
                    byte[] passwd_bytes = Encoding.UTF8.GetBytes(this.password + "\r");
                    Send(passwd_bytes);
                }
                else if (message.Contains("WebREPL connected"))
                {
                    OnLoggedIn.DynamicInvoke(this, new EventArgs());
                    checkForError = true;
                }
                else if (checkForError && message.Contains(">>>"))
                {
                    checkForError = false;
                }
                else if (checkForError && message.Contains("Traceback"))
                {
                    checkForError = false;
                    suppressMessage = true;
                }
                else if (suppressMessage && message.Contains(">>>"))
                {
                    suppressMessage = false;
                }
                else if (!suppressMessage)
                {
                    Match isAnsiEscapeCode = escapeAnsiRegex.Match(message);
                    if (isAnsiEscapeCode.Success)
                    {
                        string[] subMessages = escapeAnsiRegex.Split(message, 1);
                        OnAnsiEventCodeReceived.Invoke(this, new AnsiEscapeCodeEventArgs(Encoding.UTF8.GetBytes(subMessages[0])));
                        if (subMessages.Count() > 1)
                        {
                            message = subMessages[1];
                            isAnsiEscapeCode = escapeAnsiRegex.Match(message);
                        }
                        else
                        {
                            return;
                        }
                    }
                    Match isBackspaceEscapeCode = escapeBackspaceRegex.Match(message);
                    if(isBackspaceEscapeCode.Success)
                    {
                        OnAnsiEventCodeReceived.Invoke(this, new AnsiEscapeCodeEventArgs(e.RawData));
                        return;
                    }
                    message = message.Replace("\r\n", "\r");
                    OnMessageReceived.Invoke(this, new StringMessageEventArgs(message));
                }
            }
        }
        #endregion

        private int CheckResponseStatus(byte[] data)
        {
            if (data[0] == (byte)'W' && data[1] == (byte)'B')
            {
                var code = data[2] | (data[3] << 8);
                return code;
            }
            return -1;
        }

        public void SetSuppressMessages(bool SuppressMessages)
        {
            suppressMessage = SuppressMessages;
        }

        private void HandleBinaryStates(byte[] data)
        {
            switch (currentBinaryState)
            {
                case BinaryState.First_Put_Response:
                    // first response for put
                    if (CheckResponseStatus(data) == 0)
                    {
                        // send file data in chunks
                        for (var offset = 0; offset < fileDataToBeSent.Count; offset += 1024)
                        {
                            SendData(fileDataToBeSent.ToArray().Slice(offset, offset + 1024));
                        }
                        currentBinaryState = BinaryState.Final_Put_Response;
                    }
                    break;
                case BinaryState.Final_Put_Response:
                    // final response for put
                    if (CheckResponseStatus(data) == 0)
                    {
                        Console.WriteLine(String.Format("Sent {0}, {1} bytes", fileNameOfFileToBeSent, fileDataToBeSent.Count));
                        OnFileSent.DynamicInvoke(this,new FileSentEventArgs(FileOperationResult.Success,fileNameOfFileToBeSent,fileDataToBeSent.Count));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Failed sending {0}", fileNameOfFileToBeSent));
                        OnFileSent.DynamicInvoke(this, new FileSentEventArgs(FileOperationResult.Failure, fileNameOfFileToBeSent, -1));
                    }
                    currentBinaryState = BinaryState.None;
                    break;
                case BinaryState.First_Get_Response:
                    // first response for get
                    if (CheckResponseStatus(data) == 0)
                    {
                        currentBinaryState = BinaryState.File_Data;
                        byte[] dataPacket = new byte[] { 0x00 };
                        SendData(dataPacket);
                    }
                    break;
                case BinaryState.File_Data:
                    // file data
                    int sz = data[0] | (data[1] << 8);
                    if (data.Length == 2 + sz)
                    {
                        // we assume that the data comes in single chunks
                        if (sz == 0)
                        {
                            // end of file
                            currentBinaryState = BinaryState.Final_Response;
                        }
                        else
                        {
                            // accumulate incoming data to get_file_data
                            fileDataReceived.AddRange(data.Slice(2));
                            Console.WriteLine(String.Format("Getting {0}, {1} bytes", fileNameOfFileReceived, fileDataReceived.Count));
                            OnFileDataReceived.Invoke(this, new FileDataReceivedEventArgs(fileNameOfFileReceived, fileDataReceived.Count));
                            byte[] dataPacket = new byte[] { 0x00 };
                            SendData(dataPacket);
                        }
                    }
                    else
                    {
                        currentBinaryState = BinaryState.None;
                    }
                    break;
                case BinaryState.Final_Response:
                    // final response
                    if (CheckResponseStatus(data) == 0)
                    {
                        Console.WriteLine(String.Format("Got {0}, {1} bytes", fileNameOfFileReceived, fileDataReceived.Count));
                        OnFileReceived.DynamicInvoke(this, new FileReceivedEventArgs(FileOperationResult.Success, fileNameOfFileReceived, fileDataReceived.ToArray()));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Failed getting {0}", fileNameOfFileReceived));
                        OnFileReceived.DynamicInvoke(this, new FileReceivedEventArgs(FileOperationResult.Failure, fileNameOfFileReceived, null));
                    }
                    currentBinaryState = BinaryState.None;
                    break;
                case BinaryState.Get_Version_Response:
                    // first (and last) response for GET_VER
                    OnVersionReceived.DynamicInvoke(this, new VersionEventArgs(data));
                    currentBinaryState = BinaryState.None;
                    break;
            }
        }
    }   
}
