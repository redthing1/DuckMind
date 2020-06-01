using System.Threading;

namespace Ducia.Systems {
    public abstract class PlannerSystem<TMind, TState> : MindSystem<TMind, TState>
        where TMind : Mind<TState> where TState : MindState, new() {
        protected PlannerSystem(TMind mind, float refresh, CancellationToken cancelToken) : base(mind, refresh,
            cancelToken) { }

        protected int maxSignalsPerThink = 40;

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
                if (result) {
                    state.signalQueue.TryDequeue(out _);
                }

                processedSignals++;
                if (processedSignals > maxSignalsPerThink) break;
            }
        }

        protected abstract bool processSignal(MindSignal result);
        protected abstract void processSenses();
        protected abstract void makePlans();
    }
}