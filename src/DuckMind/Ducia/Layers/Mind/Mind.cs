using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ducia {
    /// <summary>
    ///     represents the consciousness of a Wing.
    ///     it can fully control the thoughts and actions of a bird.
    /// </summary>
    public abstract class Mind<TState> : IMind where TState : MindState, new() {
        // - state
        public readonly TState state;

        /// <summary>
        ///     the cancellation token used for all asynchronous tasks
        /// </summary>
        protected CancellationTokenSource cancelToken;

        public List<IMindSystem> cognitiveSystems = new List<IMindSystem>();

        /// <summary>
        ///     how often to sleep between consciousness updates
        /// </summary>
        public int consciousnessSleep = 100;

        private Task? consciousnessTask;

        /// <summary>
        ///     internally used to track consciousness updates only when threadpool is disabled
        /// </summary>
        private float nextSyncConsciousness;

        // - systems
        public List<IMindSystem> sensorySystems = new List<IMindSystem>();

        public Mind(TState state) {
            this.state = state;
            cancelToken = new CancellationTokenSource();
        }

        // - options
        public static bool useThreadPool { get; set; } = true;

        public int ticks { get; private set; }

        public float elapsed { get; private set; }

        public virtual void initialize() {
            // start processing tasks
            if (useThreadPool)
                consciousnessTask =
                    Task.Run(async () => await consciousnessAsync(cancelToken.Token), cancelToken.Token);
        }

        public virtual void destroy() {
            // stop processing tasks
            if (consciousnessTask != null) cancelToken!.Cancel();
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
                if (elapsed >= nextSyncConsciousness) consciousnessStep();
                nextSyncConsciousness = consciousnessSleep / 1000f;
            }

            // AUTONOMOUS pipeline - act
            act(); // carry out decisions;

            // update state information
            state.tick(dt);
        }

        public void signal(MindSignal signal) {
            state.signalQueue.Enqueue(signal);
        }

        /// <summary>
        ///     step the consciousness. one unit of thinking.
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
            foreach (var system in cognitiveSystems) system.tick();
        }

        private void sense() {
            foreach (var system in sensorySystems) system.tick();
        }
    }
}