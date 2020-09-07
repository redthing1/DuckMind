using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Ducia.Perf.Layers.Plan;

namespace Ducia.Perf {
    class Program {
        static void Main(string[] args) {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
            // var summary = BenchmarkRunner.Run<BasicVsSmartPlanner>();
        }
    }
}