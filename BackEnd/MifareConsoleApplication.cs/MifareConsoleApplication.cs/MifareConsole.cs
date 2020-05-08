﻿using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using HidGlobal.OK.Readers;

namespace MifareConsoleApplication
{
    public class MifareConsole
    {
        public static MifareAPI.LoadMifareKey LoadKeyMifareConsole = new MifareAPI.LoadMifareKey();
        public static MifareAPI.InitReader InitMifareConsole = new MifareAPI.InitReader();
        private static IContextHandler WebContext;
        private static ISmartCardReader WebReader;

        public static void InitWebReader()
        {
            WebReader = InitMifareConsole.RunInitReader();
            Console.Write(WebReader.PcscReaderName);
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
            bool check = key.RunLoadkey("FFFFFFFFFFFF");
            Console.Write(check);
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
            Console.ReadKey();
        }
    }
}
