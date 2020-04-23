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
            var result = ContextHandler.Instance;
            IReadOnlyList<string> myreaders = result.ListReaders();
            string text = myreaders[0];
            var TestReader = new SmartCardReader(text);
            string expectedreader = "HID Global OMNIKEY 5022 Smart Card Reader 0";
            Assert.AreEqual(expectedreader, TestReader.PcscReaderName);

            }
        [TestMethod]
        public void RunReaderKeyCommandTest()
        {
            var result = ContextHandler.Instance;
            
           
            long expectedHandle = -3674937291639357440;
            Assert.AreEqual(expectedHandle, result.Handle);

        }
    }

}


