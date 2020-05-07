using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using HidGlobal.OK.Readers;

public class MifareInitReader
{
      private static IContextHandler ReaderContext;
      private static ISmartCardReader MifareReader;
  public async Task<object> Invoke(object input)
  {
    ReaderContext = ContextHandler.Instance;
    IReadOnlyList<string> myreaders = ReaderContext.ListReaders();
    string readername = myreaders[0];
    MifareReader = new SmartCardReader(readername);
    return MifareReader.PcscReaderName;
  }
}
