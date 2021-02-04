using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Log4Net_Sample
{
    public class Sample3 : IExecutor
    {
        private static readonly ILog Log;

        static Sample3()
        {
            // set breakpoint and check whether static constructor is called
            Debugger.Break();

            // magic encoding provider trick from github after google-ing the error message
            // see: https://github.com/ExcelDataReader/ExcelDataReader/issues/267
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Log = LogManager.GetLogger(typeof(Sample3));
        }

        public Sample3()
        {
            // check: Log / Logger / Hierarchy / Root / Appenders
            Debugger.Break();

            // Wires up a complex config with the current logger
            XmlConfigurator.Configure(new System.IO.FileInfo("sample3.conf.xml"));
        }

        public async Task Execute()
        {
            // check Log in Watch
            Debugger.Break();

            Task.WaitAll(Enumerable.Range(0, 20).AsParallel().Select(async count =>
            {
                Log.Warn("Entering application. " + count);
                await Task.Delay(TimeSpan.FromSeconds(5));
                Log.Info("Exiting application. " + count);
            }).ToArray());
        }
    }
}
