using System;
using Ducia.Tests.Framework.Utility;
using Iri.Glass.Logging;
using Xunit;

namespace MindDemos {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("mind demos");

            var log = new Logger(Logger.Verbosity.Information);
            log.verbosity = Logger.Verbosity.Trace;
            log.sinks.Add(new Logger.ConsoleSink());

            log.info("testing cake game");
            // test cake game
            var game = new CakeGame();
            var result = game.run(100000);
            Assert.True(result);
            log.info("cake game success");
        }
    }
}