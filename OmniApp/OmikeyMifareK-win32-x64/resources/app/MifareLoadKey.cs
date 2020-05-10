using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using System.Runtime.InteropServices;

namespace HidGlobal.OK.Readers
{
    public class MifareLoadKey
    {
        
       // public static MifareAPI.InitReader InitMifareConsole = new MifareAPI.InitReader();
        //private static IContextHandler WebContext;
       // private static ISmartCardReader WebReader;
       
        public async Task<object> Invoke(dynamic input)
        {
            MifareAPI.LoadMifareKey webMifare = new MifareAPI.LoadMifareKey();

            string _input = (string)input;
          //  bool check = webMifare.RunLoadkey(_input);
            //WebReader = InitMifareConsole.RunInitReader();
            // bool _output =  LoadKeyMifareConsole.RunLoadkey(_input);
            return webMifare.RunLoadkey(_input);
        }
    }
}
