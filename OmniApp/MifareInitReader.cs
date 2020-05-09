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
    public class MifareInitReader
    {

        public async Task<object> 
            Invoke(object input)
            {
            var InitMifareBackEnd = new MifareAPI.InitReader();
            ISmartCardReader WebReader = InitMifareBackEnd.RunInitReader();
            WebReader = InitMifareBackEnd.RunInitReader();
            return WebReader.PcscReaderName;
        }

    }
}
