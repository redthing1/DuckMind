using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Glint;
using Nez;

namespace Ducia.Layer1 {
    /// <summary>
    /// represents the consciousness of a Wing.
    /// it can fully control the thoughts and actions of a bird.
    /// </summary>
    public abstract class Mind<TState> : Component, IUpdatable
        where TState : MindState, new() {
        // - options
        public static bool useThreadPool { get; set; }

        public TState state;
        public List<IMindSystem> sensorySystems = new List<IMindSystem>();
        public List<IMindSystem> cognitiveSystems = new List<IMindSystem>();
        public bool inspected = false;

        public int consciousnessSleep = 100;
        private Task? consciousnessTask;
        protected CancellationTokenSource? cancelToken;

        public Mind(TState state) {
            this.state = state;
        }

        public override void OnAddedToEntity() {
            base.OnAddedToEntity();

            // mind systems
            var cts = new CancellationTokenSource();
            cancelToken = cts;

            // start processing tasks
            if (useThreadPool) {
                consciousnessTask = Task.Run(async () => await consciousnessAsync(cts.Token), cts.Token);
            }
        }

        /// <summary>
        /// step the consciousness. one unit of thinking.
        /// </summary>
        private void consciousnessStep() {
            think();
        }

        public async Task consciousnessAsync(CancellationToken tok) {
            while (!tok.IsCancellationRequested) {
                consciousnessStep();

                await Task.Delay(consciousnessSleep, tok);
            }
        }

        #region Component Implementation

        public void Update() {
            // Sense-Think-Act AI
            sense(); // sense the world around
            act(); // carry out decisions();

            // if thread-pooled AI is disabled, do synchronous consciousness
            if (!useThreadPool && consciousnessTask == null) {
                var msPassed = (int) (Time.DeltaTime * 1000);
                var thinkModulus = consciousnessSleep / msPassed;
                if (Time.FrameCount % thinkModulus == 0) {
                    consciousnessStep();
                }
            }

            // update state information
            state.tick(Time.DeltaTime);
        }

        public override void OnRemovedFromEntity() {
            base.OnRemovedFromEntity();

            // stop processing tasks
            if (consciousnessTask != null) {
                cancelToken!.Cancel();
            }
        }

        #endregion

        protected virtual void act() { }

        protected virtual void think() {
            // think based on information and make plans
            try {
                foreach (var system in cognitiveSystems) {
                    system.tick();
                }
            }
            catch (Exception e) {
                // log exceptions in think
                Global.log.err($"error thinking: {e}");
            }
        }

        private void sense() {
            foreach (var system in sensorySystems) {
                system.tick();
            }
        }

        public void signal(MindSignal signal) {
            state.signalQueue.Enqueue(signal);
        }
    }
}