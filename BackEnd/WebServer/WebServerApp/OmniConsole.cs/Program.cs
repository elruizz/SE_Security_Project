using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using HidGlobal.OK.Readers;

namespace OmniConsole.cs
{
    class Program
    {
        private static IContextHandler WebContext;
        private static ISmartCardReader WebReader;

        public static void InitWebReader()
        {
            WebContext = ContextHandler.Instance;
            IReadOnlyList<string> myreaders = WebContext.ListReaders();
            string readername = myreaders[0];
            WebReader = new SmartCardReader(readername);
        }
        public static void runReadMifare()
        {
            var read = new MifareAPI.ReadMifareClassic1k();
            read.Run(WebReader.PcscReaderName);

        }
        public static void runWriteMifare()
        {
            var write = new MifareAPI.UpdateMifareClassic1k();
            write.Run(WebReader.PcscReaderName, "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }
        public static void runLoadkey()
        {
            var key = new MifareAPI.LoadMifareKey();
            key.Run(WebReader.PcscReaderName, "FFFFFFFFFFFF");
        }
        public static void run()
        {
            InitWebReader();
            Console.WriteLine(WebReader.PcscReaderName + ContextHandler.Instance.Handle);
            runLoadkey();
            runWriteMifare();
            runReadMifare();


        }
        static void Main(string[] args)
        {
            run();
        }
    }
}
