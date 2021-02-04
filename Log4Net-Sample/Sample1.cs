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
    public class Sample1 : IExecutor
    {
        private static readonly ILog Log;

        static Sample1()
        {
            // set breakpoint and check whether static constructor is called
            Debugger.Break();

            Log = LogManager.GetLogger(typeof(Sample1)); // Name: Log4Net_Sample.Sample1
        }

        public Sample1()
        {
            // check: Log / Logger / Hierarchy / Root / Appenders
            Debugger.Break();

            // Set up a simple configuration that logs on the console.
            BasicConfigurator.Configure();
        }

        public async Task Execute()
        {
            // check Log in Watch
            Debugger.Break();

            Log.Info("Entering application.");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Log.Info("Exiting application.");
        }
    }
}
