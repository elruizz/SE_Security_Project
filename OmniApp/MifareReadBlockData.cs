using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidGlobal.OK.Readers
{
    class MifareReadBlockData
    {
        public async Task<object>
            Invoke(object input)
        {
            byte _input = 0x04;
            var _read = new MifareAPI.ReadMifareClassic1k();
            var InitMifareBackEnd = new MifareAPI.InitReader();
            ISmartCardReader WebReader = InitMifareBackEnd.RunInitReader();
            WebReader = InitMifareBackEnd.RunInitReader();
           return _read.RunReadMifare(_input);
        }

    }
}
