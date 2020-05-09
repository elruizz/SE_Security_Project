using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidGlobal.OK.Readers
{
    class MifareWriteBlockData
    {
        
        public async Task<object>
           Invoke(object input)
        {
            byte _blockinput = 4;
            var _write = new MifareAPI.UpdateMifareClassic1k();
            var InitMifareBackEnd = new MifareAPI.InitReader();

           
            string _input = (string)input;
            
            ISmartCardReader WebReader = InitMifareBackEnd.RunInitReader();
            WebReader = InitMifareBackEnd.RunInitReader();
            return _write.RunWriteMifare(_input, _blockinput);
        }
    }
}
