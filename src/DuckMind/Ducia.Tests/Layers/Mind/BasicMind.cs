using System;
using System.Threading;

namespace Ducia.Tests.Layers.Mind {
    public class BasicMind : Mind<BasicMind.State> {
        public class State : MindState { }

        public BasicMind() : base(new State()) { }

        public override void initialize() {
            base.initialize();

            sensorySystems.Add(new RhythmSystem(this, 0.5f, cancelToken.Token));
            cognitiveSystems.Add(new RandomSeedSystem(this, 0.5f, cancelToken.Token));
        }

        /// <summary>
        /// represents a system that tracks beats. every time it processes, it simply increments the beat counter.
        /// </summary>
        public class RhythmSystem : MindSystem<BasicMind, State> {
            public int beats = 0;

            public RhythmSystem(BasicMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
                cancelToken) { }

            protected override void process() {
                beats++;
            }
        }

        /// <summary>
        /// represents a system that calculates and stores a random number
        /// </summary>
        public class RandomSeedSystem : MindSystem<BasicMind, State> {
            public Random rng = new Random();
            public int state = -1; // -1 indicates uninitialized

            public RandomSeedSystem(BasicMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
                cancelToken) { }

            protected override void process() {
                // this always gives us a nonnegative integer
                state = rng.Next();
            }
        }
    }
}