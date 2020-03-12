﻿/*****************************************************************************************
    (c) 2017-2018 HID Global Corporation/ASSA ABLOY AB.  All rights reserved.

      Redistribution and use in source and binary forms, with or without modification,
      are permitted provided that the following conditions are met:
         - Redistributions of source code must retain the above copyright notice,
           this list of conditions and the following disclaimer.
         - Redistributions in binary form must reproduce the above copyright notice,
           this list of conditions and the following disclaimer in the documentation
           and/or other materials provided with the distribution.
           THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
           AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
           THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
           ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
           FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
           (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
           LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
           ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
           (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
           THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*****************************************************************************************/
using System;
using HidGlobal.OK.Readers;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers.Components;
using HidGlobal.OK.SampleCodes.Utilities;

namespace HidGlobal.OK.SampleCodes.AViatoR
{
    public class GetDataExample
    {
        public void Run(string readerName)
        {
            var reader = new SmartCardReader(readerName);
            
            try
            {
                ConsoleWriter.Instance.PrintSplitter();
                ConsoleWriter.Instance.PrintTask($"Connecting to {reader.PcscReaderName}");

                ReaderHelper.ConnectToReaderWithCard(reader);

                ConsoleWriter.Instance.PrintMessage($"Connected\nConnection Mode: {reader.ConnectionMode}");

                ReaderHelper.GetDataCommand(reader, "Get Data Command", GetDataCommand.Type.Default);

                ConsoleWriter.Instance.PrintSplitter();
            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                    ConsoleWriter.Instance.PrintMessage("Reader connection closed");
                }
                ConsoleWriter.Instance.PrintSplitter();
            }
        }
    }
    public class GetHistoricalBytesExample
    {
        public void Run(string readerName)
        {
            var reader = new SmartCardReader(readerName);
            
            try
            {
                ConsoleWriter.Instance.PrintSplitter();
                ConsoleWriter.Instance.PrintTask($"Connecting to {reader.PcscReaderName}");

                ReaderHelper.ConnectToReaderWithCard(reader);

                ConsoleWriter.Instance.PrintMessage($"Connected\nConnection Mode: {reader.ConnectionMode}");

                ReaderHelper.GetDataCommand(reader, "Get Historical Bytes", GetDataCommand.Type.Specific);

                ConsoleWriter.Instance.PrintSplitter();
            }
            catch (Exception e)
            {
                ConsoleWriter.Instance.PrintError(e.Message);
            }
            finally
            {
                if (reader.IsConnected)
                {
                    reader.Disconnect(CardDisposition.Unpower);
                    ConsoleWriter.Instance.PrintMessage("Reader connection closed");
                }
                ConsoleWriter.Instance.PrintSplitter();
            }
        }
    }
}
