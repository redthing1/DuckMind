using BenchmarkDotNet.Attributes;
using Ducia.Tests.Framework.Utility;
using Xunit;

namespace Ducia.Perf.Framework {
    public class CakeGamePerf {
        private CakeGame game;
        // [Params(100, 1000, 10000, 100000)] public int N;
        [Params(10000)] public int N;
        
        [GlobalSetup]
        public void setup() {
            game = new CakeGame();
        }

        [Benchmark]
        public bool runCakeGame() {
            var result = game.run(N);
            Assert.True(result);
            return result;
        }
    }
}