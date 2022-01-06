using System;
using System.Collections.Concurrent;
using System.Threading;
using Ducia.Systems;
using Xunit;

namespace Ducia.Tests.Layers.Mind; 

public class BasicMind : Mind<BasicMind.State> {
    public BasicMind() : base(new State()) { }

    public override void initialize() {
        base.initialize();

        sensorySystems.Add(new RhythmSystem(this, 0.5f, cancelToken.Token));
        cognitiveSystems.Add(new RandomSeedSystem(this, 0.5f, cancelToken.Token));
        cognitiveSystems.Add(new TaxReturnsSystem(this, 0.5f, cancelToken.Token));
    }

    public class State : MindState {
        public ConcurrentQueue<PlanTask> plan = new();
    }

    /// <summary>
    ///     represents a system that tracks beats. every time it processes, it simply increments the beat counter.
    /// </summary>
    public class RhythmSystem : MindSystem<BasicMind, State> {
        public int beats;

        public RhythmSystem(BasicMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
            cancelToken) { }

        protected override void process() {
            beats++;
        }
    }

    /// <summary>
    ///     represents a system that calculates and stores a random number
    /// </summary>
    public class RandomSeedSystem : MindSystem<BasicMind, State> {
        public Random rng = new();
        public int state = -1; // -1 indicates uninitialized

        public RandomSeedSystem(BasicMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
            cancelToken) { }

        protected override void process() {
            // this always gives us a nonnegative integer
            state = rng.Next();
        }
    }

    public class TaxReturnsSystem : PlannerSystem<BasicMind, State> {
        public int paid;

        public TaxReturnsSystem(BasicMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
            cancelToken) { }

        protected override bool processSignal(MindSignal signal) {
            if (signal is BillSignal bill) {
                paid += bill.price;
                return true;
            }

            return false;
        }

        protected override void makePlans() {
            // nothing to do here
        }
    }

    public class BillSignal : MindSignal {
        public BillSignal(int price) {
            this.price = price;
        }

        public int price { get; }
    }

    public class PushButtonTask : PlanTask<BasicMind> {
        public PushButtonTask(BasicMind mind, float expiryTime = 0) : base(mind, expiryTime) { }
        public bool pressed { get; private set; }

        public override Status status() {
            if (base.status() == Status.Failed) return Status.Failed; // check base conditions

            if (pressed) return Status.Complete;

            return Status.Ongoing;
        }

        public void press() {
            Assert.False(pressed);
            pressed = true;
        }
    }
}