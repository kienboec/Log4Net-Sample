using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Log4Net_Sample
{
    public class Sample5 : IExecutor
    {
        private static readonly ILog Log;

        static Sample5()
        {
            // set breakpoint and check whether static constructor is called
            Debugger.Break();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            PatternLayout patternLayout = new PatternLayout
            {
                ConversionPattern = "%date %level %message%newline"
            };
            patternLayout.ActivateOptions();

            var coloredConsoleAppender = new ColoredConsoleAppender();
            coloredConsoleAppender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                BackColor = ColoredConsoleAppender.Colors.White,
                ForeColor = ColoredConsoleAppender.Colors.Purple,
                Level = Level.Info
            });
            coloredConsoleAppender.Layout = patternLayout;
            coloredConsoleAppender.ActivateOptions();

            var rollingFileAppender = new RollingFileAppender
            {
                File = "sample5.log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                DatePattern = "yyyyMMdd-HHmm",
                Layout = patternLayout
            };
            rollingFileAppender.ActivateOptions();

            // var hierarchy = (Hierarchy)LogManager.GetRepository();
            // hierarchy.Root.AddAppender(coloredConsoleAppender);
            // hierarchy.Root.AddAppender(rollingFileAppender);
            // hierarchy.Root.Level = Level.All;
            // hierarchy.Configured = true;
            // BasicConfigurator.Configure(hierarchy); // <-- here a console will additionally be added

            BasicConfigurator.Configure(coloredConsoleAppender);
            BasicConfigurator.Configure(rollingFileAppender);

            Log = LogManager.GetLogger(typeof(Sample5));
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
