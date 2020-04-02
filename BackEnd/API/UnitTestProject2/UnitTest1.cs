using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Run(string readerName)
        {
            var reader = new SmartCardReader(readerName);

            ReaderHelper.ConnectToReaderWithCard(reader);

            ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x04,
                GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
            ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x04, 0x00);

            ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x05,
                GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
            ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x05, 0x00);

            ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x06,
                GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
            ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x06, 0x00);

            ReaderHelper.GeneralAuthenticateMifare(reader, "Authenticate with key from slot nr ", 0x07,
                GeneralAuthenticateCommand.MifareKeyType.MifareKeyA, 0x02);
            ReaderHelper.ReadBinaryMifareCommand(reader, "Read Binary block nr ", 0x07, 0x00);


            if (reader.IsConnected)
            {

                reader.Disconnect(CardDisposition.Unpower);


            }
        }
    }
}
