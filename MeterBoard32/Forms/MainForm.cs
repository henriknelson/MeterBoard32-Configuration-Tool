using System;
using BrightIdeasSoftware;
using MeterBoard32.Classes;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using MeterBoard32.Classes.WebREPL;
using static MeterBoard32.Classes.WebREPL.WebREPLEvents;

namespace MeterBoard32.Forms
{
    public partial class MeterBoard32Form : Form
    {
        // MeterBoard32 configuration path/filename
        private const string CONFIG_FILENAME = ".config/meter_config.json";

        // Client to communicate with the MeterBoard32 using MicroPythons WebREPL
        private WebReplClient client;

        // The textbox used in the console component
        private RichTextBox consoleTextBox;

        // The list of meters currently loaded in the configuration tool
        private MeterList meters = new MeterList();
        private TypedObjectListView<Meter> meterList;

        // Internal state variables to handle communication with the MeterBoard32
        private bool keyActionInvoked = false;
        private bool clearLine = false;

        // The expected amount of characters we want to suppress in order to not show echo in console
        private int expectedEchoSize = 1;

        public MeterBoard32Form()
        {
            InitializeComponent();
            consoleTextBox = consoleControl.InternalRichTextBox;
            consoleControl.SendKeyboardCommandsToProcess = true;
            consoleTextBox.KeyDown += ConsoleTextBox_KeyDown;
            consoleTextBox.KeyPress += ConsoleTextBox_KeyPress;
            consoleTextBox.ContextMenuStrip = contextMenuStrip1;
        }

        #region Windows Form Event Handlers

        private void MeterBoard32Form_Load(object sender, EventArgs e)
        {
            // Set up Meter list view
            meterList = new TypedObjectListView<Meter>(objectListView1);
            meterList.GetColumn(0).AspectGetter = delegate (Meter x) { return x.MeterId; };
            meterList.GetColumn(1).AspectGetter = delegate (Meter x) { return x.PrimaryAddress; };
            meterList.GetColumn(2).AspectGetter = delegate (Meter x) { return x.MeterType; };
            meterList.GetColumn(3).AspectGetter = delegate (Meter x) { return x.ManufacturerId; };
            meterList.GetColumn(4).AspectGetter = delegate (Meter x) { return x.dataRecords.Count; };
            meterList.GetColumn(5).AspectGetter = delegate (Meter x) { return "Delete"; };
            meterList.GetColumn(6).AspectGetter = delegate (Meter x) { return "Modify"; };
            meterList.ListView.ButtonClick += delegate (object sender2, CellClickEventArgs e2) {
                Meter meter = (Meter)e2.Model;
                if (e2.ColumnIndex == 5)
                {
                    meters.Remove(meter);
                    objectListView1.RemoveObject(meter);
                }
                else if (e2.ColumnIndex == 6)
                {
                    MeterForm meterForm = new MeterForm(ref meter);
                    if (meterForm.ShowDialog(this).Equals(DialogResult.OK))
                    {
                        objectListView1.UpdateObject(meter);
                    }
                }
                objectListView1.RefreshObject(e2.Model);
            };

            // Set up console component
            consoleControl.WriteOutput("Welcome to MeterBoard32 Configuration Tool console!\r", Color.White);
            consoleTextBox.ReadOnly = true;
        }


        /// <summary>
        /// Event handler for the "Connect" button
        /// Tries to establish a connection with a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnect_Click(object sender, EventArgs e)
        {

            // Sanity check to see if we might already be connected..
            if (client != null && client.ReadyState.Equals(WebSocketState.Open))
                return;

            // Fetch connection parameters from GUI
            string ip_address = ipTextBox.Text;
            string password = passwordTxtBox.Text;

            try
            {
                // Validate connection parameters
                if (!Helpers.ValidateIPv4(ip_address))
                    throw new Exception("Malformed IP address");

                // Set up WebSocket client to MeterBoard32 webrepl
                client = new WebReplClient(ip_address, 8266, password);
                client.OnConnected += Client_OnConnected;
                client.OnLoggedIn += Client_OnLoggedIn;
                client.OnDisconnected += Client_OnDisconnected;
                client.OnMessageReceived += Client_OnMessage;
                client.OnAnsiEventCodeReceived += Client_OnAnsiCodeReceived;
                client.OnError += Client_OnError;
                client.OnFileReceived += Client_OnFileReceived;
                client.OnFileDataReceived += Client_OnFileDataReceived;
                client.OnFileSent += Client_OnFileSent;
                client.OnVersionReceived += Client_OnVersionReceived;

                // Try to connect to MeterBoard32..
                client.Connect();
            }
            catch (Exception ex)
            {
                ShowInfo(string.Format("Error connecting to MeterBoard32: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Sends every single keypress in the console to the MeterBoard32's WebREPL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsoleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Send(e.KeyChar.ToString());
            expectedEchoSize += 1;
        }

        /// <summary>
        /// Sends special input to the MeterBoard32's WebREPL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsoleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //  If we're at the input point and it's backspace, bail.
            if (((consoleTextBox.SelectionStart <= GetInputStart()) && e.KeyCode == Keys.Back) 
                || ((consoleTextBox.SelectionStart <= GetInputStart()) && e.KeyCode == Keys.Left))
            {
                e.SuppressKeyPress = true;
            }

            //  Are we in the read-only zone?
            else if (consoleTextBox.SelectionStart < GetInputStart())
            {
                //  Allow arrows and Ctrl-C.
                if (!(e.KeyCode == Keys.Left 
                    || e.KeyCode == Keys.Right 
                     || e.KeyCode == Keys.Up 
                      || e.KeyCode == Keys.Down 
                       || (e.KeyCode == Keys.C && e.Control)))
                {
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                Send("\t");
                keyActionInvoked = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Return)
            {
                Send("\r");
                keyActionInvoked = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                Send("\x1b[A");
                keyActionInvoked = true;
                clearLine = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                Send("\x1b[B");
                keyActionInvoked = true;
                clearLine = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Home)
            {
                Send("\x1bOH");
                keyActionInvoked = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Send("\x03\r\n");
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Sends the current configuration to the MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendConfiguration_Click(object sender, EventArgs e)
        {       
            
            string jsonData = JsonConvert.SerializeObject(meters, Formatting.Indented);
            byte[] fileData = Encoding.UTF8.GetBytes(jsonData);
            ShowInfo(string.Format("Sending configuration file {0} to MeterBoard32 ({1} byte)..", CONFIG_FILENAME, fileData.Count()));
            client.SendFile(CONFIG_FILENAME, fileData);
        }

        /// <summary>
        /// Reads the current configuration from the MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadConfiguration_Click(object sender, EventArgs e)
        {
            ShowInfo(string.Format("Fetching configuration file {0} from MeterBoard32..", CONFIG_FILENAME));
            client.GetFile(CONFIG_FILENAME);
        }

        /// <summary>
        /// Saves the current configuration to disc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveConfigurationDialog = new SaveFileDialog
            {
                Filter = "Meter Configuration File|*.meter",
                Title = "Save Meter Configuration"
            };

            saveConfigurationDialog.ShowDialog();
            string fileName = saveConfigurationDialog.FileName;
            if (fileName != "")
            {
                ShowInfo(string.Format("Saving configuration file {0} to disc..", fileName));
                FileStream fs = (FileStream)saveConfigurationDialog.OpenFile();
                string json = JsonConvert.SerializeObject(meters, Formatting.Indented);
                fs.Write(Encoding.UTF8.GetBytes(json), 0, Encoding.UTF8.GetByteCount(json));
                fs.Close();
                ShowInfo(string.Format("Configuration file {0} saved to disc", fileName));
            }
        }

        /// <summary>
        /// Loads a configuration from disc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadConfiguration_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog
            {
                Filter = "Meter Configuration File|*.meter",
                Title = "Load Meter Configuration"
            };

            string fileName = loadFileDialog.FileName;
            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                ShowInfo(string.Format("Loading configuration file {0} from disc..", fileName));
                StreamReader sr = new StreamReader(fileName);
                string json = sr.ReadToEnd();
                sr.Close();
                ShowInfo(string.Format("Configuration file {0} successfully loaded from disc", fileName));
                meters.Clear();
                MeterList meterList = (MeterList)JsonConvert.DeserializeObject(json, typeof(MeterList));
                meters.AddRange(meterList);
                updateGUI();
            }
        }

        /// <summary>
        /// Event handler for the "Add Meter" button
        /// Provides the user with a means of adding a new meter to the current configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMeter_Click(object sender, EventArgs e)
        {
            MeterForm meterForm = new MeterForm();
            if (meterForm.ShowDialog(this).Equals(DialogResult.OK))
            {
                meters.Add(meterForm.resultMeter);
                ShowInfo(string.Format("Added meter {0} to current configuration", meterForm.resultMeter.MeterId));
                updateGUI();
            }
        }

        /// <summary>
        /// Event handler for the "Get Version" button
        /// Sends a GetVersion request to the connected MeterBoard32 and, if successful, displays the response in the console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetVersion_Click(object sender, EventArgs e)
        {
            client.GetVersion();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consoleTextBox.SelectionLength > 0)
                Clipboard.SetText(consoleTextBox.SelectedText, TextDataFormat.Text);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consoleTextBox.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "(c) 2018 Henrik Nelson", "About");
        }
        #endregion


        #region WebSocket event handlers

        /// <summary>
        /// Callback in the event of a successful socket connection to a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnConnected(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ShowInfo("Connected to MeterBoard32");
                SetStatus(true);
            });
        }

        /// <summary>
        /// Callback in the event of a MeterBoard32 socket disconnection to MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnDisconnected(object sender, CloseEventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ShowInfo(string.Format("Disconnected from MeterBoard32 (Reason: {0})", e.Reason));
                SetStatus(false);
            });
        }

        /// <summary>
        /// Callback in the event of a successfully login to a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnLoggedIn(object sender, EventArgs e)
        {
            // If the MBus handler is currently running on the MeterBoard32,
            // we must send CTRL+C to interrupt it!
            Invoke((MethodInvoker)delegate {
                Send("\x03\r");
            });
        }

        /// <summary>
        /// Callback in the event of an error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnError(object sender, ErrorEventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ShowInfo(string.Format("Error: {0}", e.Message));
                SetStatus(false);
            });
        }

        /// <summary>
        /// Callback in the event of a file data received status update received from a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnFileDataReceived(object sender, FileDataReceivedEventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ShowInfo(string.Format("Receiving file data - '{0}', ({1} bytes so far) ..", e.Filename, e.CurrentCount));
            });
        }

        /// <summary>
        /// Callback in the event of a successful file received operation from a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnFileReceived(object sender, FileReceivedEventArgs e)
        {
            if (e.Result == FileOperationResult.Success)
            {
                string jsonString = Encoding.UTF8.GetString(e.Data);
                meters.Clear();
                MeterList meterList = (MeterList)JsonConvert.DeserializeObject(jsonString, typeof(MeterList));
                meters.AddRange(meterList);
                Invoke((MethodInvoker)delegate
                {
                    ShowInfo(string.Format("File '{0}' ({1} bytes) received successfully", e.Name, e.Data.Count()));
                    updateGUI();
                });
            }
        }

        /// <summary>
        /// Callback in the event of a successful file sent operation to a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnFileSent(object sender, FileSentEventArgs e)
        {
            if (e.Result == FileOperationResult.Success)
            {
                Invoke((MethodInvoker)delegate {
                    ShowInfo(string.Format("File '{0}' ({1} bytes) sent successfully", e.Name, e.Length));
                    RestartHandler();
                });
            }
        }

        /// <summary>
        /// Callback in the event of a successful response of a GetVersion request sent to a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnVersionReceived(object sender, VersionEventArgs e)
        {
            Invoke((MethodInvoker)delegate {
                ShowInfo(string.Format("MeterBoard version {0} (based on MicroPython {1})", e.MeterBoardVersion, e.MicroPythonVersion));
            });
        }

        /// <summary>
        /// Callback in the event of a incoming message from a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnMessage(object sender, StringMessageEventArgs e)
        {
            string dataStr = e.Message;
            Color currentColor = Color.Red;
            if (expectedEchoSize <= 0)
            {
                if (keyActionInvoked)
                    currentColor = Color.White;

                consoleControl.Invoke((MethodInvoker)delegate
                {
                    if(clearLine)
                        ClearInput();

                    consoleTextBox.AppendText(dataStr, currentColor);
                });

                consoleControl.Invoke((MethodInvoker)delegate {
                    consoleControl.WriteOutput("", Color.White);
                });

                keyActionInvoked = false;
                clearLine = false;
            }
            if (expectedEchoSize > 0)
            {
                expectedEchoSize -= dataStr.Length;
                if (expectedEchoSize < 0)
                    expectedEchoSize = 0;
            }
        }

        /// <summary>
        /// Callback in the event of a ANSI escape code received from a MeterBoard32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_OnAnsiCodeReceived(object sender, AnsiEscapeCodeEventArgs e)
        {
            Console.WriteLine(string.Format("ANSI escape sequence received: {0}", Encoding.UTF8.GetString(e.EscapeCode)));
            string hexCode = BitConverter.ToString(e.EscapeCode).Replace("-","");
            if (hexCode.Equals("1B5B4B"))
            {
                consoleControl.Invoke((MethodInvoker)delegate
                {
                    ClearInput();
                });
            }
            else if(hexCode[0] == 0x08)
            {
                consoleControl.Invoke((MethodInvoker)delegate
                {
                    RemoveLast(hexCode.Count());
                });
            }
        }
        #endregion

        
        #region Application Logic

        /// <summary>
        /// Tries to stop any ongoing MBus handler running on the MeterBoard32
        /// Then, tries to re-start the handler once again
        /// </summary>
        private void RestartHandler()
        {
            ShowInfo("Stopping MBus handler..");
            client.SetSuppressMessages(true);
            Send("\x03\r");
            ShowInfo("Starting MBusHandler..");
            Send("handler.start()\r");
        }

        /// <summary>
        /// Refreshes the currently shown list of meters
        /// </summary>
        public void updateGUI()
        {
            meterList.ListView.SetObjects(meters);
        }

        /// <summary>
        /// Reflects the provided connection state in the GUI
        /// </summary>
        /// <param name="connected">A boolean indicating weather we should reflect a connected or disconnected state</param>
        private void SetStatus(bool connected)
        {
            if (connected)
            {
                connectedLabel.Text = "Connected";
                consoleTextBox.ReadOnly = false;
                btnConnect.Text = "Disconnect";
                consoleTextBox.Focus();
                btnReadConfiguration.Enabled = true;
                btnSendConfiguration.Enabled = true;
                btnGetVersion.Enabled = true;
            }
            else
            {
                connectedLabel.Text = "Not connected";
                consoleTextBox.Clear();
                consoleTextBox.ReadOnly = true;
                btnConnect.Text = "Connect";
                btnConnect.Focus();
                btnReadConfiguration.Enabled = false;
                btnSendConfiguration.Enabled = false;
                btnGetVersion.Enabled = false;
            }
        }

        /// <summary>
        /// Shows a special information string in the console
        /// </summary>
        /// <param name="info">The information string to show in the console</param>
        private void ShowInfo(string info)
        {
            consoleControl.WriteOutput(info + "\r", Color.Green);
            consoleControl.WriteOutput(">>> ", Color.Red);
            consoleControl.WriteOutput("", Color.White);
            consoleControl.Focus();
        }

        private int GetInputStart()
        {
            int lastPrompt = consoleTextBox.Text.LastIndexOf(">>> ");
            if (lastPrompt > -1)
            {
                lastPrompt += 4;
            }
            return lastPrompt;
        }

        private void ClearInput()
        {
            int lastPrompt = GetInputStart();
            consoleTextBox.SelectionStart = lastPrompt;  // or wherever you want to insert..
            consoleTextBox.SelectionLength = consoleTextBox.Text.Count() - lastPrompt;
            consoleTextBox.SelectedText = "";
            consoleControl.WriteOutput("", Color.White);
        }

        private void RemoveLast(int countFromEnd)
        {
            consoleTextBox.SelectionStart = consoleTextBox.Text.Count() - countFromEnd;
            consoleTextBox.SelectionLength = countFromEnd;
            consoleTextBox.SelectedText = "";
            consoleControl.WriteOutput("", Color.White);
        }

        private void Send(string data)
        {
            client.SendData(data);
        }

        private void Send(byte[] data)
        {
            client.SendData(data);
        }
        #endregion

    }
}
