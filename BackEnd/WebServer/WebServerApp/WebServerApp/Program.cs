﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using HidGlobal.OK.Readers;
using HidGlobal.OK.Readers.Components;
using HidGlobal.OK.SampleCodes.MenuSections;
using HidGlobal.OK.SampleCodes.Utilities;

namespace WebServer
{
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;

        public WebServer(IReadOnlyCollection<string> prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
            {
                throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");
            }

            // URI prefixes are required eg: "http://localhost:8080/test/"
            if (prefixes == null || prefixes.Count == 0)
            {
                throw new ArgumentException("URI prefixes are required");
            }

            if (method == null)
            {
                throw new ArgumentException("responder method required");
            }

            foreach (var s in prefixes)
            {
                _listener.Prefixes.Add(s);
            }

            _responderMethod = method;
            _listener.Start();
        }

        public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
           : this(prefixes, method)
        {
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Console.WriteLine("Webserver running...");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                if (ctx == null)
                                {
                                    return;
                                }

                                var rstr = _responderMethod(ctx.Request);
                                var buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch
                            {
                                // ignored
                            }
                            finally
                            {
                                // always close the stream
                                if (ctx != null)
                                {
                                    ctx.Response.OutputStream.Close();
                                }
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex)
                {
                    // ignored
                }
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }
    }

    internal class Program
    {
        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }

        //private static IMenuItem _rootMenu = new MenuItem("HID OMNIKEY Smart Card Readers' Sample Codes Application Menu", true);
        
        
        //private static IMenuSection _keyboardWedgesSection = new KeyboardWedgesMenuSection(KeyboardWedgesMenuFactory.Instance);
        //private static IMenuSection _smartCardReadersSection = new SmartCardReadersMenuSection(SmartCardReadersMenuFactory.Instance);
        private static readonly Scope scope = Scope.System;
        private static string deviceName = "-3674937291639357440";
        IReadOnlyList<string> readerName;

        private static void Main(string[] args)
        {


            var reader = ContextHandler.Instance;

           
            reader.IsValid();
            reader.Establish(scope);
            //reader.IntroduceReader(readerName, deviceName);
            //ReaderHelper.GetSerialNumber(readerName);
            reader.ListReaders();
            Console.WriteLine();
            
            //var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
            //ws.Run();
            
            //_rootMenu.AddSubItem(_smartCardReadersSection.RootMenuItem);
            //_rootMenu.AddSubItem(_keyboardWedgesSection.RootMenuItem);

            //_rootMenu.Execute();
            //Console.WriteLine("A simple webserver. Press enter key to quit.");
            //Console.ReadKey();
            //ws.Stop();
        }
    }


}
