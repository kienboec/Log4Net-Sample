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
    public class Sample2 : IExecutor
    {
        private static readonly ILog Log;

        static Sample2()
        {
            // set breakpoint and check whether static constructor is called
            Debugger.Break();

            Log = LogManager.GetLogger(typeof(Sample2));
        }

        public Sample2()
        {
            // check: Log / Logger / Hierarchy / Root / Appenders
            Debugger.Break();

            // Wires up a complex config with the current logger
            // throws no error if file not found :-(
            // use "copy always" / "content" for the config file in props-window
            XmlConfigurator.Configure(new System.IO.FileInfo("sample2.conf.xml"));

            // Alternative: [assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
        }

        public async Task Execute()
        {
            // check Log in Watch
            Debugger.Break();

            for (var i = 0; i < 3; i++)
            {
                Log.Info("Entering application.");
                await Task.Delay(TimeSpan.FromSeconds(5));
                Log.Info("Exiting application.");
            }

            /* sample output: 
            3353[1] INFO Log4Net_Sample.Sample2(null) - Entering application.
            8669[5] INFO Log4Net_Sample.Sample2(null) - Exiting application.
            8669[5] INFO Log4Net_Sample.Sample2(null) - Entering application.
            13688[4] INFO Log4Net_Sample.Sample2(null) - Exiting application.
            13689[4] INFO Log4Net_Sample.Sample2(null) - Entering application.
            18705[5] INFO Log4Net_Sample.Sample2(null) - Exiting application.
            */
        }
    }
}
