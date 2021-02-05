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
    class Sample4 : IExecutor
    {
        class Item
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return $"{Key}: {Value}";
            }
        }

        private static readonly ILog Log;

        static Sample4()
        {
            // set breakpoint and check whether static constructor is called
            Debugger.Break();

            Log = LogManager.GetLogger(typeof(Sample4));
            GlobalContext.Properties["Application"] = "Sample4";
        }

        public Sample4()
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

            var items = new Item[]
            {
                new Item() {Key = "Key1", Value = "Value1"},
                new Item() {Key = "Key2", Value = "Value2"},
                new Item() {Key = "Key3", Value = "Value3"},
            };

            Log.Info("Entering application.");
            Log.Debug("items[0]");
            Log.Debug(items[0]);
            Log.Debug("___________________________________________");
            Log.Debug("items");
            Log.Debug(items);
            Log.Debug("___________________________________________");
            Log.Debug("new { key, value}");
            Log.Debug(new { Key = items[0].Key, Value = items[0].Value });
            await Task.Delay(TimeSpan.FromSeconds(5));
            Log.Info("Exiting application.");
        }
    }
}
