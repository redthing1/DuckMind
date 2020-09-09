using Activ.GOAP;
using BenchmarkDotNet.Attributes;
using Ducia.Tests.Layers.Plan;

namespace Ducia.Perf.Layers.Plan {
    [MemoryDiagnoser]
    public class BasicVsSmartPlanner {
        private BasicRoomCleaner basicCleaner;
        private SmartRoomCleaner smartCleaner;
        private int workGoal;

        [Params(100, 1000, 10000)] public int N;

        [GlobalSetup]
        public void setup() {
            basicCleaner = new BasicRoomCleaner();
            smartCleaner = new SmartRoomCleaner();

            workGoal = N;
        }

        [Benchmark]
        public Node<BasicRoomCleaner>[] solveBasicCleaner() {
            var solver = new Solver<BasicRoomCleaner>();
            solver.maxIter = solver.maxNodes = workGoal * 10; // unlock
            var plan = solver.Next(basicCleaner, new Goal<BasicRoomCleaner>(x => x.workDone >= workGoal));
            return plan.Path();
        }

        [Benchmark]
        public Node<SmartRoomCleaner>[] solveSmartCleaner() {
            var solver = new Solver<SmartRoomCleaner>();
            solver.maxIter = solver.maxNodes = workGoal * 10; // unlock
            var plan = solver.Next(smartCleaner, new Goal<SmartRoomCleaner>(x => x.workDone >= workGoal));
            return plan.Path();
        }
    }
}