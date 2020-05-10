using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HidGlobal.OK.Readers
{
    class MifareWriteBlockData
    {
        
        public async Task<object>
           Invoke(dynamic input)
        {
            var _write = new MifareAPI.UpdateMifareClassic1k();
            var InitMifareBackEnd = new MifareAPI.InitReader();
            string _input = (string)input._input;
            byte _blockinput = Byte.Parse(input._blockinput, NumberStyles.HexNumber);
            ISmartCardReader WebReader = InitMifareBackEnd.RunInitReader();
            WebReader = InitMifareBackEnd.RunInitReader();
            return _write.RunWriteMifare(_input, _blockinput);
        }
    }
}
