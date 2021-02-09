using System;
using System.Threading.Tasks;

namespace Log4Net_Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region Docs

            // log4net is based on the highly successful Apache log4j™ logging library,
            // in development since 1996.
            //
            // This popular and proven architecture has so far been ported to 12 languages (see http://logging.apache.org/ ).

            // Features ( http://logging.apache.org/log4net/release/features.html ):
            // - Output to multiple logging targets (see: Out of the box Appenders
            // - Hierarchical logging architecture
            // - Dynamic XML Configuration
            // - Logging Context (e.g.: Thread Context)
            // - Proven architecture
            // - Modular and extensible design
            // - High performance with flexibility

            // Components:
            // - loggers (hierarchical - like namespaces; split with dots / root (default: debug) always exists / child inherits from parent),
            // - appenders ( http://logging.apache.org/log4net/release/features.html ) and
            // - layouts ( https://logging.apache.org/log4net/release/sdk/html/T_log4net_Layout_PatternLayout.htm )
            //
            // with filters (should I print this message?) and
            // objects renderer (object -> string)

            // LOG LEVEL
            // - ALL ( TRACE )
            // - DEBUG
            // - INFO
            // - WARN
            // - ERROR
            // - FATAL
            // - OFF

            // Compliant Alternatives to .net core abstractions: 
            //     https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/april/essential-net-logging-with-net-core
			//     https://docs.microsoft.com/en-us/dotnet/core/extensions/logging
            // - NLog
            // - Serilog

            #endregion

            IExecutor sample =
                new Sample1();
                // new Sample2();
                // new Sample3();
                // new Sample4();
                // new Sample5();

            await sample.Execute();
        }
    }
}
