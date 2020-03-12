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

namespace HidGlobal.OK.Readers.SecureSession
{
    public interface ISecureChannel : IDisposable
    {
        /// <summary>
        /// True if secure channel is established.
        /// </summary>
        bool IsSessionActive { get; }
        /// <summary>
        /// Establish secure channel with given key and access wrights defined by key slot.
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="sessionKeySlotNumber"></param>
        void Establish(string sessionKey, byte sessionKeySlotNumber);
        /// <summary>
        /// Establish secure channel with given key and access wrights defined by key slot.
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="sessionKeySlotNumber"></param>
        void Establish(byte[] sessionKey, byte sessionKeySlotNumber);
        /// <summary>
        /// Closes current channel.
        /// </summary>
        void Terminate();
        /// <summary>
        /// Encrypts and send given command. Returns decrypted response.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string SendCommand(string command);
        /// <summary>
        /// Encrypts and send given command. Returns decrypted response.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        byte[] SendCommand(byte[] command);
    }
}
