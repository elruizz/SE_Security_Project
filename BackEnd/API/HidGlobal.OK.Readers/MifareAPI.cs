﻿using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using System;
using System.Linq;
using System.Collections.Generic;


namespace HidGlobal.OK.Readers
{
    public class MifareAPI
    {
        private static IContextHandler ReaderContext;
        private static ISmartCardReader MifareReader;
        public class InitReader
        {
            
            public void RunInitReader()
            {
               
                ReaderContext = ContextHandler.Instance;
                IReadOnlyList<string> myreaders = ReaderContext.ListReaders();
                string readername = myreaders[0];
                MifareReader = new SmartCardReader(readername);
            }
        }
       
            public class LoadMifareKey
            {
            public string MifareOutput = "";
            public string MifareAPDU = "";

            private void LoadKeyCommand(ISmartCardReader smartCardReader, byte keySlot, LoadKeyCommand.KeyType keyType, LoadKeyCommand.Persistence persistence, LoadKeyCommand.Transmission transmission, LoadKeyCommand.KeyLength keyLength, string key)
                {
                    var loadKeyCommand = new Readers.AViatoR.Components.LoadKeyCommand();

                    string input = loadKeyCommand.GetApdu(keySlot, keyType, persistence, transmission, keyLength, key);
                    string output = ReaderHelper.SendCommand(smartCardReader, input);
                //ConsoleWriter.Instance.PrintCommand(description + key, input, output);
                Console.WriteLine($"input {input}  Load Key Output:  {output}  Key: {key}");
                MifareOutput = output;
                MifareAPDU = input;
               
            }
                public void Run(string readerName, string Keyresponse)
                {
                    var reader = new SmartCardReader(readerName);

                    try
                    {
                        ConsoleWriter.Instance.PrintTask($"Connecting to { reader.PcscReaderName}");
                        ReaderHelper.ConnectToReader(reader);


                        LoadKeyCommand(reader, 0x01,
                            Readers.AViatoR.Components.LoadKeyCommand.KeyType.CardKey,
                            Readers.AViatoR.Components.LoadKeyCommand.Persistence.Persistent,
                            Readers.AViatoR.Components.LoadKeyCommand.Transmission.Plain,
                            Readers.AViatoR.Components.LoadKeyCommand.KeyLength._6Bytes, Keyresponse);

                        
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
            public class ReadMifareClassic1k
            {
           
            public void Run(string readerName)
                {
                    var reader = new SmartCardReader(readerName);

                    try
                    {
                        Console.WriteLine($"Connecting to {reader.PcscReaderName}");

                        ReaderHelper.ConnectToReaderWithCard(reader);
                        // Authenticate is SMARTCARDREADER, BLOCK NUMBER, KEYTYPE, KEYSLOT

                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x04,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                        ReaderHelper.ReadBinaryMifareCommand(reader, 0x04, 0x00);

                        ReaderHelper.GeneralAuthenticateMifare(reader,  0x05,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                        ReaderHelper.ReadBinaryMifareCommand(reader,  0x05, 0x00);

                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x06,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                        ReaderHelper.ReadBinaryMifareCommand(reader,  0x06, 0x00);
                    
                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x07,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                        ReaderHelper.ReadBinaryMifareCommand(reader, 0x07, 0x00);
                    
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
            public class UpdateMifareClassic1k
            {
                public void Run(string readerName, string data)
                {
                    var reader = new SmartCardReader(readerName);

                    try
                    {

                        Console.WriteLine($"Connecting to {reader.PcscReaderName}");

                        ReaderHelper.ConnectToReaderWithCard(reader);

                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x04,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                        ReaderHelper.UpdateBinaryCommand(reader, UpdateBinaryCommand.Type.Plain, 0x04, data); // Data can be 32 bytes long

                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x05,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                        ReaderHelper.UpdateBinaryCommand(reader, UpdateBinaryCommand.Type.Plain, 0x05, data);

                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x06,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);

                        ReaderHelper.UpdateBinaryCommand(reader, UpdateBinaryCommand.Type.Plain, 0x06, data);
                    /*
                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x04,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                        ReaderHelper.UpdateBinaryCommand(reader, UpdateBinaryCommand.Type.Plain, 0x04, data);
                     */
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
            public class IncrementMifareClassic1k
            {
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
                void SendIncrementCommand(ISmartCardReader smartCardReader, int value, byte blockNumber)
                {
                    var incrementCommand = new IncrementCommand();
                    string input = incrementCommand.GetApdu(blockNumber, value);
                    string output = ReaderHelper.SendCommand(smartCardReader, input);

                    Console.WriteLine("Input ", input, "Output: ", output);
                }
                public void Run(string readerName)
                {
                    var reader = new SmartCardReader(readerName);
                    try
                    {

                        Console.WriteLine($"Connecting to {reader.PcscReaderName}");

                        ReaderHelper.ConnectToReaderWithCard(reader);

                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x04,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                        // Update block 4 with write operation in value block format:
                        // 4 byte value LSByte first, 4 byte bit inverted represetaton of value LSByte first, 4 byte value LSByte first, 1 byte block address, 1 byte bit inverted block address, 1 byte block address, 1 byte bit inverted block address
                        string valueTypeData = GetMifareValueTypeData(1234567, 0x04);
                        ReaderHelper.UpdateBinaryCommand(reader, UpdateBinaryCommand.Type.Plain, 0x04, valueTypeData);

                        SendIncrementCommand(reader, 1, 0x04);

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
            public class DecrementMifareClassic1k
            {
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
                void SendDecrementCommand(ISmartCardReader smartCardReader, int value, byte blockNumber)
                {
                    var decrementCommand = new DecrementCommand();
                    string input = decrementCommand.GetApdu(blockNumber, value);
                    string output = ReaderHelper.SendCommand(smartCardReader, input);

                    Console.WriteLine("Input: ", input, "\n Output: ", output);
                }
                public void Run(string readerName)
                {
                    var reader = new SmartCardReader(readerName);
                    try
                    {

                        ReaderHelper.ConnectToReaderWithCard(reader);
                        ReaderHelper.GeneralAuthenticateMifare(reader, 0x04,
                            GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x00);
                        // Update block 4 with write operation in value block format:
                        // 4 byte value LSByte first, 4 byte bit inverted represetaton of value LSByte first, 4 byte value LSByte first, 1 byte block address, 1 byte bit inverted block address, 1 byte block address, 1 byte bit inverted block address
                        string valueTypeData = GetMifareValueTypeData(1234567, 0x04);
                        ReaderHelper.UpdateBinaryCommand(reader,
                            UpdateBinaryCommand.Type.Plain, 0x04, valueTypeData);

                        SendDecrementCommand(reader, 1, 0x04);


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
        }
    }

