using System;
using HidGlobal.OK.Readers;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.SampleCodes.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAuth
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

            public void Run(string readerName)
        {
            var reader = new SmartCardReader(readerName);
            var testReader = new SmartCardReader(readerName);
            try
            {

                ReaderHelper.ConnectToReaderWithCard(reader);
                Assert.AreEqual(testReader, reader);
               
                /*
                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x04,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x04, 0x00);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x05,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x05, 0x00);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x06,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x01);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x06, 0x00);

                ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x07,
                    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
                ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x07, 0x00);
                */
               // Assert.AreEqual(testReader, reader);
            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(HidGlobal.OK.Readers.Components.CardDisposition.Unpower);
                    ConsoleWriter.Instance.PrintMessage("Reader connection closed");
                }
                ConsoleWriter.Instance.PrintSplitter();
            }
        }

    }

}
