using System.Threading;

namespace Ducia.Systems {
    public abstract class PlannerSystem<TMind, TState> : MindSystem<TMind, TState>
        where TMind : Mind<TState> where TState : MindState, new() {
        protected PlannerSystem(TMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
            cancelToken) { }

        /// <summary>
        /// sets the limit on the maximum number of signals that can be processed per update.
        /// set to 0 to disable limit.
        /// </summary>
        protected int maxSignalsPerUpdate = 0;

        protected override void process() {
            // look at signals
            processSignals();

            // mind responses to the senses
            processSenses();

            // figure out plans
            makePlans();
        }

        private void processSignals() {
            var processedSignals = 0;
            while (state.signalQueue.TryPeek(out var signal)) {
                // process the signal
                var result = processSignal(signal);
                // if successfully handled, remove it from the queue
                if (result) {
                    state.signalQueue.TryDequeue(out _);
                } else {
                    // signal failed to be handled
                    // ???
                    throw new InvalidMindStateException("signal failed to be processed");
                }

                processedSignals++;

                // if we hit the signal limit, stop
                if (maxSignalsPerUpdate > 0)
                    if (processedSignals > maxSignalsPerUpdate)
                        break;
            }
        }

        /// <summary>
        /// handle mind signals
        /// </summary>
        /// <param name="signal"></param>
        /// <returns>whether the signal was handled</returns>
        protected abstract bool processSignal(MindSignal signal);

        /// <summary>
        /// preprocessing to run on results of sensory systems
        /// </summary>
        protected virtual void processSenses() { }

        /// <summary>
        /// make plans based on available information
        /// </summary>
        protected abstract void makePlans();
    }
}