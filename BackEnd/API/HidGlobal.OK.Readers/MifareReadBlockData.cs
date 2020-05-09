using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidGlobal.OK.Readers
{
    class MifareReadBlockData
    {
        public async Task<string>
            Invoke(object input)
        {
            var _read = new MifareAPI.ReadMifareClassic1k();
            var InitMifareBackEnd = new MifareAPI.InitReader();
            ISmartCardReader WebReader = InitMifareBackEnd.RunInitReader();
            WebReader = InitMifareBackEnd.RunInitReader();
            return WebReader.PcscReaderName;
        }

    }
}
