using BenchmarkDotNet.Running;

namespace Ducia.Perf {
    class Program {
        static void Main(string[] args) {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}