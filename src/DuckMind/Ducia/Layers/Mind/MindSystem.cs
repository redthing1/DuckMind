using System.Threading;

namespace Ducia {
    public interface IMindSystem {
        bool tick();
    }

    /// <summary>
    ///     Represents a system of a mind with a refresh rate
    /// </summary>
    public abstract class MindSystem<TMind, TState> : IMindSystem
        where TMind : Mind<TState>
        where TState : MindState, new() {
        protected CancellationToken cancelToken;
        public TMind mind;
        public float nextRefreshAt;
        public float refresh;
        protected TState state;

        public MindSystem(TMind mind, float refresh, CancellationToken cancelToken) {
            this.mind = mind;
            state = mind.state;
            this.refresh = refresh;
            this.cancelToken = cancelToken;
        }

        /// <summary>
        ///     Ticks the mind, calling process if it is time.
        /// </summary>
        /// <returns>Whether process was called.</returns>
        public virtual bool tick() {
            if (mind.elapsed >= nextRefreshAt) {
                nextRefreshAt = mind.elapsed + refresh;
                process();
                return true;
            }

            return false;
        }

        protected abstract void process();
    }
}