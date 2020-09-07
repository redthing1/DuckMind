using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Ducia.Perf {
    class Program {
        static void Main(string[] args) {
            #if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
            #else
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            #endif
        }
    }
}