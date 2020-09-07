using BenchmarkDotNet.Running;
using Ducia.Perf.Layers.Plan;

namespace Ducia.Perf {
    class Program {
        static void Main(string[] args) {
            var summary = BenchmarkRunner.Run<BasicVsSmartPlanner>();
        }
    }
}