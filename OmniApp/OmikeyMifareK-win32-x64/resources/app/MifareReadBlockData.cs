using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace HidGlobal.OK.Readers
{
    class MifareReadBlockData
    {
        public async Task<object>
            Invoke(dynamic input)
        {

            byte _input = Byte.Parse(input, NumberStyles.HexNumber);
            var _read = new MifareAPI.ReadMifareClassic1k();
            var InitMifareBackEnd = new MifareAPI.InitReader();
            ISmartCardReader WebReader = InitMifareBackEnd.RunInitReader();
            WebReader = InitMifareBackEnd.RunInitReader();
           return _read.RunReadMifare(_input);
        }

    }
}
