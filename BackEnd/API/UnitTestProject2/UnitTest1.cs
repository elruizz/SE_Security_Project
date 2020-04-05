using HidGlobal.OK.Readers;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using HidGlobal.OK.SampleCodes.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Run(string readerName)
        {
            var reader = new SmartCardReader(readerName);

            //TODO: We need a to arange the test so it tests the key and authentiactes.

            var test = new SmartCardReader(readerName);
           

            ReaderHelper.ConnectToReader(reader);

            ReaderHelper.ConnectToReader(test);//connecting test to the reader

            ReaderHelper.GeneralAuthenticateMifare(test, "Authenticate with key ", 0x01, GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02); //sending test to be authenticated
            ReaderHelper.ReadBinaryMifareCommand(test, "Read Binary block nr ", 0x01, 0x00); 

            ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x01,
                GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
            
            ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x01, 0x00);

            Assert.AreSame(reader, test); //Assert test to compare if reader and test are the same

            //ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x05,
               // GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
           // ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x05, 0x00);

           // ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x06,
            //    GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
          //  ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x06, 0x00);

          //  ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x07,
         //       GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
           // ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x07, 0x00);

            reader.Disconnect(CardDisposition.Unpower);
            test.Disconnect(CardDisposition.Unpower);
        }
    }
}
