using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.ComponentModel;
using HidGlobal.OK.Readers.Components;
using HidGlobal.OK.Readers.AViatoR.Components;
using HidGlobal.OK.Readers;

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

        internal class Program
        {
            public static string SendResponse(HttpListenerRequest request)
            {
                return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);

            }


            //   private static IMenuItem _rootMenu = new MenuItem("HID OMNIKEY Smart Card Readers' Sample Codes Application Menu", true);

            // private static IMenuSection _keyboardWedgesSection = new KeyboardWedgesMenuSection(KeyboardWedgesMenuFactory.Instance);
            //  private static IMenuSection _smartCardReadersSection = new SmartCardReadersMenuSection(SmartCardReadersMenuFactory.Instance);
            //  public static string rName = "";
            // private static ISmartCardReader smartC = new SmartCardReader(rName);
            // private static web_con = new IContextHandler.Instance;

            private static Scope scope = Scope.System;




            public static void run()
            {

                var result = ContextHandler.Instance;
                IReadOnlyList<string> myreaders = result.ListReaders();
                string text = myreaders[0];
                //var keycommand = new Load



                // var sReader = new SmartCardReader(result.ListReaders());
                //result.IsValid();
                //  result.Establish(scope);

                var WebReader = new SmartCardReader(text);
                Console.WriteLine(WebReader.PcscReaderName);
                var key = new MifareAPI.LoadMifareKey();
                key.Run(WebReader.PcscReaderName, "FFFFFFFFFFFF");

                //  WebReader.Connect();



            }



            // private static ISmartCardReader _reader = new SmartCardReader(ContextHandler.Instance);

            // private static Scope web_previousScope;
            //  private static IContextHandler web_instance;



            private static void Main(string[] args)
            {

                //web_con.

                var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
                //  ws.Run();
                run();

                //  _rootMenu.AddSubItem(_smartCardReadersSection.RootMenuItem);
                //   _rootMenu.AddSubItem(_keyboardWedgesSection.RootMenuItem);
                // web_con.Establish(web_previousScope);
                //  web_instance.Establish(web_previousScope);
                //   _rootMenu.Execute();
                Console.WriteLine("A simple webserver. Press enter key to quit.");
                Console.ReadKey();
                // ws.Stop();
            }
        }

    }
}
