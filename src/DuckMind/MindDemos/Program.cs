using System;
using Ducia.Tests.Framework.Utility;
using Xunit;

namespace MindDemos {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("mind demos");
            
            // test cake game
            var game = new CakeGame();
            var result = game.run(100000);
            Assert.True(result);
        }
    }
}