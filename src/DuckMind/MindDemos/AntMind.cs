using System.Threading;
using Ducia;

namespace MindDemos {
    public class AntMind : Mind<AntMind.State> {
        public class State : MindState { }

        public class PheromoneSystem : MindSystem<AntMind, State> {
            public PheromoneSystem(AntMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh, cancelToken) { }
            protected override void process() {
                throw new System.NotImplementedException();
            }
        }

        public AntMind(State state) : base(state) {
            sensorySystems.Add(new PheromoneSystem(this, 0.2f, cancelToken.Token));
        }
    }
}