using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using HidGlobal.OK.Readers;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using HidGlobal.OK.SampleCodes.MenuSections;
using HidGlobal.OK.SampleCodes.Utilities;

namespace WebServer
{
 
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;

        public WebServer(IReadOnlyCollection<string> prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
            {
                throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");
            }

            // URI prefixes are required eg: "http://localhost:8080/test/"
            if (prefixes == null || prefixes.Count == 0)
            {
                throw new ArgumentException("URI prefixes are required");
            }

            if (method == null)
            {
                throw new ArgumentException("responder method required");
            }

            foreach (var s in prefixes)
            {
                _listener.Prefixes.Add(s);
            }

            _responderMethod = method;
            _listener.Start();
        }

        public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
           : this(prefixes, method)
        {
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Console.WriteLine("Webserver running...");

                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                if (ctx == null)
                                {
                                    return;
                                }

                                var rstr = _responderMethod(ctx.Request);
                                var buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch
                            {
                                // ignored
                            }
                            finally
                            {
                                // always close the stream
                                if (ctx != null)
                                {
                                    ctx.Response.OutputStream.Close();
                                }
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex)
                {
                    // ignored
                }
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }

        private void LoadKeyCommand(ISmartCardReader smartCardReader, string description, byte keySlot, LoadKeyCommand.KeyType keyType, LoadKeyCommand.Persistence persistence, LoadKeyCommand.Transmission transmission, LoadKeyCommand.KeyLength keyLength, string key)
        {
            var loadKeyCommand = new HidGlobal.OK.Readers.AViatoR.Components.LoadKeyCommand();

            string input = loadKeyCommand.GetApdu(keySlot, keyType, persistence, transmission, keyLength, key);
            string output = ReaderHelper.SendCommand(smartCardReader, input);
        }

        public void LoadCard(string readerName)
        {
            var reader = new SmartCardReader(readerName);

            try
            {
                ReaderHelper.ConnectToReader(reader);

                LoadKeyCommand(reader, "Load Mifare Key: ", 0x00,
                    HidGlobal.OK.Readers.AViatoR.Components.LoadKeyCommand.KeyType.CardKey,
                    HidGlobal.OK.Readers.AViatoR.Components.LoadKeyCommand.Persistence.Persistent,
                    HidGlobal.OK.Readers.AViatoR.Components.LoadKeyCommand.Transmission.Plain,
                    HidGlobal.OK.Readers.AViatoR.Components.LoadKeyCommand.KeyLength._6Bytes, "FFFFFFFFFFFF");
            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                }

            }
        }

        public void Reading(string readerName)
        {
            var reader = new SmartCardReader(readerName);

            try
            {

                ReaderHelper.ConnectToReaderWithCard(reader);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x04,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x04, 0x00);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x05,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x05, 0x00);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x06,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x06, 0x00);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x07,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x07, 0x00);

            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                }

            }
        }

        public void Update(string readerName)
        {
            var reader = new SmartCardReader(readerName);

            try
            {

                ReaderHelper.ConnectToReaderWithCard(reader);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x04,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.UpdateBinaryCommand(reader, "Update Binary block nr ", UpdateBinaryCommand.Type.Plain, 0x04, "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x05,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.UpdateBinaryCommand(reader, "Update Binary block nr ", UpdateBinaryCommand.Type.Plain, 0x05, "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x06,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                ReaderHelper.UpdateBinaryCommand(reader, "Update Binary block nr ", UpdateBinaryCommand.Type.Plain, 0x06, "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");

            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                }
            }
        }

        string GetMifareValueTypeData(int value, byte blockNumber)
        {
            var valueBytes = BitConverter.GetBytes(value);
            var invertedValueBytes = BitConverter.GetBytes(~value);
            if (!BitConverter.IsLittleEndian)
            {
                valueBytes = valueBytes.Reverse().ToArray();
                invertedValueBytes = invertedValueBytes.Reverse().ToArray();
            }
            string lsbFirstValue = BitConverter.ToString(valueBytes).Replace("-", "");
            string lsbFirstInvertedValue = BitConverter.ToString(invertedValueBytes).Replace("-", "");

            return lsbFirstValue + lsbFirstInvertedValue + lsbFirstValue + $"{blockNumber:X2}" +
                   ((byte)~blockNumber).ToString("X2") + $"{blockNumber:X2}" +
                   ((byte)~blockNumber).ToString("X2");
        }

        void SendIncrementCommand(ISmartCardReader smartCardReader, string description, int value, byte blockNumber)
        {
            var incrementCommand = new IncrementCommand();
            string input = incrementCommand.GetApdu(blockNumber, value);
            string output = ReaderHelper.SendCommand(smartCardReader, input);

        }

        public void Increment(string readerName)
        {
            var reader = new SmartCardReader(readerName);
            try
            {
                ReaderHelper.ConnectToReaderWithCard(reader);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x04,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                // Update block 4 with write operation in value block format:
                // 4 byte value LSByte first, 4 byte bit inverted represetaton of value LSByte first, 4 byte value LSByte first, 1 byte block address, 1 byte bit inverted block address, 1 byte block address, 1 byte bit inverted block address
                string valueTypeData = GetMifareValueTypeData(1234567, 0x04);
                ReaderHelper.UpdateBinaryCommand(reader, "Create value type in block nr ",
                    UpdateBinaryCommand.Type.Plain, 0x04, valueTypeData);

                SendIncrementCommand(reader, "Increment value in block nr: ", 1, 0x04);

            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                }
            }
        }

        void SendDecrementCommand(ISmartCardReader smartCardReader, string description, int value, byte blockNumber)
        {
            var decrementCommand = new DecrementCommand();
            string input = decrementCommand.GetApdu(blockNumber, value);
            string output = ReaderHelper.SendCommand(smartCardReader, input);
        }

        public void Decrement(string readerName)
        {
            var reader = new SmartCardReader(readerName);
            try
            {
                ConsoleWriter.Instance.PrintSplitter();
                ConsoleWriter.Instance.PrintTask($"Connecting to {reader.PcscReaderName}");

                ReaderHelper.ConnectToReaderWithCard(reader);

                ConsoleWriter.Instance.PrintMessage($"Connected\nConnection Mode: {reader.ConnectionMode}");
                ConsoleWriter.Instance.PrintSplitter();

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x04,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                // Update block 4 with write operation in value block format:
                // 4 byte value LSByte first, 4 byte bit inverted represetaton of value LSByte first, 4 byte value LSByte first, 1 byte block address, 1 byte bit inverted block address, 1 byte block address, 1 byte bit inverted block address
                string valueTypeData = GetMifareValueTypeData(1234567, 0x04);
                ReaderHelper.UpdateBinaryCommand(reader, "Create value type in block nr ",
                    UpdateBinaryCommand.Type.Plain, 0x04, valueTypeData);

                SendDecrementCommand(reader, "Decrement value in block nr: ", 1, 0x04);

                ConsoleWriter.Instance.PrintSplitter();
            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                }
            }
        }
    }

    internal class Program
    { 
        

        public static string SendResponse(HttpListenerRequest request)
        {
            var reader = ContextHandler.Instance;

            IReadOnlyList<string> myReader = reader.ListReaders();
            string text = myReader[0];
            

            return string.Format("<HTML><BODY>My web page.<br> {0} <br> {1} </BODY></HTML>", DateTime.Now, text);
        }

        //private static IMenuItem _rootMenu = new MenuItem("HID OMNIKEY Smart Card Readers' Sample Codes Application Menu", true);
        
        
        //private static IMenuSection _keyboardWedgesSection = new KeyboardWedgesMenuSection(KeyboardWedgesMenuFactory.Instance);
        //private static IMenuSection _smartCardReadersSection = new SmartCardReadersMenuSection(SmartCardReadersMenuFactory.Instance);
        //private static readonly Scope scope = Scope.System;
        //private static string deviceName = "-3674937291639357440";

        
        private static void Main(string[] args)
        {

            //reader.IsValid();
            //reader.Establish(scope);
            //reader.IntroduceReader(readerName, deviceName);
            //ReaderHelper.GetSerialNumber(readerName);
            //reader.ListReaders();
            //reader.ListReaders(readerName);
            
            var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
            ws.Run();
            
            
            
            
            //_rootMenu.AddSubItem(_smartCardReadersSection.RootMenuItem);
            //_rootMenu.AddSubItem(_keyboardWedgesSection.RootMenuItem);

            //_rootMenu.Execute();
            Console.WriteLine("A simple webserver. Press enter key to quit.");
            Console.ReadKey();
            ws.Stop();
        }
    }


}
