using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Glint;
using Nez;

namespace Ducia {
    /// <summary>
    /// represents the consciousness of a Wing.
    /// it can fully control the thoughts and actions of a bird.
    /// </summary>
    public abstract class Mind<TState> : Component, IUpdatable
        where TState : MindState, new() {
        // - options
        protected static bool useThreadPool { get; set; }

        public readonly TState state;
        protected List<IMindSystem> sensorySystems = new List<IMindSystem>();
        protected List<IMindSystem> cognitiveSystems = new List<IMindSystem>();
        public bool inspected = false;

        public int consciousnessSleep = 100;
        private Task? consciousnessTask;
        protected CancellationTokenSource cancelToken;

        public Mind(TState state) {
            this.state = state;
            cancelToken = new CancellationTokenSource();
        }

        public override void OnAddedToEntity() {
            base.OnAddedToEntity();

            // start processing tasks
            if (useThreadPool) {
                consciousnessTask = Task.Run(async () => await consciousnessAsync(cancelToken.Token), cancelToken.Token);
            }
        }

        /// <summary>
        /// step the consciousness. one unit of thinking.
        /// </summary>
        private void consciousnessStep() {
            think();
        }

        private async Task consciousnessAsync(CancellationToken tok) {
            while (!tok.IsCancellationRequested) {
                consciousnessStep();

                await Task.Delay(consciousnessSleep, tok);
            }
        }

        #region Component Implementation

        public void Update() {
            // Sense-Think-Act AI
            
            // AUTONOMOUS pipeline - sense
            sense(); // sense the world around

            // if thread-pooled AI is disabled, do synchronous consciousness
            // this runs the CONSCIOUS pipeline on the AUTONOMOUS pipeline's thread
            if (!useThreadPool && consciousnessTask == null) {
                var msPassed = (int) (Time.DeltaTime * 1000);
                var thinkModulus = consciousnessSleep / msPassed;
                if (Time.FrameCount % thinkModulus == 0) {
                    consciousnessStep();
                }
            }
            
            // AUTONOMOUS pipeline - act
            act(); // carry out decisions;

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