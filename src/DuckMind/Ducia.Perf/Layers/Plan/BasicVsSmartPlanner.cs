using Activ.GOAP;
using BenchmarkDotNet.Attributes;
using Ducia.Tests.Layers.Plan;

namespace Ducia.Perf.Layers.Plan {
    public class BasicVsSmartPlanner {
        private BasicRoomCleaner basicCleaner;
        private SmartRoomCleaner smartCleaner;
        private byte[] data;

        [Params(100, 1000, 10000)] public int workGoal;

        [GlobalSetup]
        public void Setup() {
            basicCleaner = new BasicRoomCleaner();
            smartCleaner = new SmartRoomCleaner();
        }

        [Benchmark]
        public Node<BasicRoomCleaner>[] solveBasicCleaner() {
            var solver = new Solver<BasicRoomCleaner>();
            var plan = solver.Next(basicCleaner, new Goal<BasicRoomCleaner>(x => x.workDone >= workGoal));
            return plan.Path();
        }

        [Benchmark]
        public Node<SmartRoomCleaner>[] solveSmartCleaner() {
            var solver = new Solver<SmartRoomCleaner>();
            var plan = solver.Next(smartCleaner, new Goal<SmartRoomCleaner>(x => x.workDone >= workGoal));
            return plan.Path();
        }
    }
}