using System;
using System.Collections.Generic;
using HidGlobal.OK.Readers;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using HidGlobal.OK.Readers.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API_Testing
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
            public void RunReaderNameTest()
            {
            var Testresult = ContextHandler.Instance;
            IReadOnlyList<string> myreaders = Testresult.ListReaders();
            string text = myreaders[0];
            var TestReader = new SmartCardReader(text);
            string expectedreader = "HID Global OMNIKEY 5022 Smart Card Reader 0";
            Assert.AreEqual(expectedreader, TestReader.PcscReaderName);

            }
        [TestMethod]
        public void RunReaderKeyCommandTest()
        {
            var Testresult = ContextHandler.Instance;
            IReadOnlyList<string> myreaders = Testresult.ListReaders();
            string text = myreaders[0];
            var TestReader = new SmartCardReader(text);
            string TestKey = "FFFFFFFFFFFF";
            string expectedApdu = "FF82200106FFFFFFFFFFFF";
            var loadkey = new MifareAPI.LoadMifareKey();
            
            loadkey.Run(TestReader.PcscReaderName, TestKey);

            Assert.AreEqual(expectedApdu, loadkey.MifareAPDU);
        }
        [TestMethod]
        public void RunReaderAuthenticateCommandTest()
        {
            var Testresult = ContextHandler.Instance;
            IReadOnlyList<string> myreaders = Testresult.ListReaders();
            string text = myreaders[0];
            var TestReader = new SmartCardReader(text);
            
        }
    }

}


