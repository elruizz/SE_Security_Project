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
    class MifareLoadKey
    {
        public IContextHandler WebContext;
        public ISmartCardReader WebReader;
        public async Task<object> Invoke(object input)
        {
            WebContext = ContextHandler.Instance;
            IReadOnlyList<string> myreaders = WebContext.ListReaders();
            string readername = myreaders[0];
            WebReader = new SmartCardReader(readername);
            return WebReader.PcscReaderName;
        }
        

    


    }
}
