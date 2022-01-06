using System;
using System.Threading;
using Ducia;

namespace MindDemos; 

public class AntMind : Mind<AntMind.State> {
    public AntMind(State state) : base(state) {
        sensorySystems.Add(new PheromoneSystem(this, 0.2f, cancelToken.Token));
    }

    public class State : MindState { }

    public class PheromoneSystem : MindSystem<AntMind, State> {
        public PheromoneSystem(AntMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
            cancelToken) { }

        protected override void process() {
            throw new NotImplementedException();
        }
    }
}