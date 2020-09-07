using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ducia {
    /// <summary>
    /// represents the consciousness of a Wing.
    /// it can fully control the thoughts and actions of a bird.
    /// </summary>
    public abstract class Mind<TState> : IMind where TState : MindState, new() {
        // - options
        public static bool useThreadPool { get; set; } = true;

        // - state
        public readonly TState state;

        public int ticks { get; private set; }

        public float elapsed { get; private set; } = 0;

        // - systems
        protected List<IMindSystem> sensorySystems = new List<IMindSystem>();
        protected List<IMindSystem> cognitiveSystems = new List<IMindSystem>();

        private Task? consciousnessTask;
        protected CancellationTokenSource cancelToken;

        /// <summary>
        /// how often to sleep between consciousness updates
        /// </summary>
        public int consciousnessSleep = 100;

        public Mind(TState state) {
            this.state = state;
            cancelToken = new CancellationTokenSource();
        }

        public virtual void initialize() {
            // start processing tasks
            if (useThreadPool) {
                consciousnessTask =
                    Task.Run(async () => await consciousnessAsync(cancelToken.Token), cancelToken.Token);
            }
        }

        public virtual void destroy() {
            // stop processing tasks
            if (consciousnessTask != null) {
                cancelToken!.Cancel();
            }
        }

        public void tick(float dt) {
            elapsed += dt;
            ticks++;

            // Sense-Think-Act AI

            // AUTONOMOUS pipeline - sense
            sense(); // sense the world around

            // if thread-pooled AI is disabled, do synchronous consciousness
            // this runs the CONSCIOUS pipeline on the AUTONOMOUS pipeline's thread
            if (!useThreadPool && consciousnessTask == null) {
                var msPassed = (int) (dt * 1000);
                var thinkModulus = consciousnessSleep / msPassed;
                if (ticks % thinkModulus == 0) {
                    consciousnessStep();
                }
            }

            // AUTONOMOUS pipeline - act
            act(); // carry out decisions;

            // update state information
            state.tick(dt);
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

        protected virtual void act() { }

        protected virtual void think() {
            // think based on information and make plans
            foreach (var system in cognitiveSystems) {
                system.tick();
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