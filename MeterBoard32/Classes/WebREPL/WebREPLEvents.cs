using System;

namespace MeterBoard32.Classes.WebREPL
{
    public class WebREPLEvents
    {
        public enum FileOperationResult
        {
            Failure, Success
        }

        public class StringMessageEventArgs : EventArgs
        {
            public string Message { get; }
            internal StringMessageEventArgs(string message)
            {
                Message = message;
            }
        }

        public class FileSentEventArgs : EventArgs
        {
            public FileOperationResult Result { get; }
            public string Name { get; }
            public int Length { get; }
            internal FileSentEventArgs(FileOperationResult result, string name, int length)
            {
                Result = result;
                Name = name;
                Length = length;
            }
        }

        public class FileReceivedEventArgs : EventArgs
        {
            public FileOperationResult Result { get; }
            public string Name { get; }
            public byte[] Data { get; }
            internal FileReceivedEventArgs(FileOperationResult result, string name, byte[] data)
            {
                Result = result;
                Name = name;
                Data = data;
            }
        }

        public class VersionEventArgs : EventArgs
        {
            public string MeterBoardVersion { get; }
            public string MicroPythonVersion { get; }
            internal VersionEventArgs(byte[] version)
            {
                MeterBoardVersion = String.Format("{0}.{1}", version[0], version[1]);
                MicroPythonVersion = String.Format("{0}.{1}.{2}", version[2], version[3], version[4]);
            }
        }

        public class AnsiEscapeCodeEventArgs : EventArgs
        {
            public byte[] EscapeCode { get; }
            internal AnsiEscapeCodeEventArgs(byte[] escapeCode)
            {
                EscapeCode = escapeCode;
            }
        }

        public class FileDataReceivedEventArgs : EventArgs
        {
            public string Filename { get; }
            public int CurrentCount { get; }
            internal FileDataReceivedEventArgs(string filename, int currentCount)
            {
                Filename = filename;
                CurrentCount = currentCount;
            }
        }
    }
}
