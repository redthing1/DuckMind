using System.Threading;
using Nez;

namespace Ducia {
    public interface IMindSystem {
        bool tick();
    }
    
    /// <summary>
    /// Represents a system of a mind with a refresh rate
    /// </summary>
    public abstract class MindSystem<TMind, TState> : IMindSystem
        where TMind : Mind<TState>
        where TState : MindState, new() {
        
        public TMind mind;
        protected TState state;
        public float refresh;
        public float nextRefreshAt;
        protected Entity entity;
        protected CancellationToken cancelToken;

        public MindSystem(TMind mind, float refresh, CancellationToken cancelToken) {
            this.mind = mind;
            this.state = mind.state;
            this.entity = mind.Entity;
            this.refresh = refresh;
            this.cancelToken = cancelToken;
        }

        protected abstract void process();

        /// <summary>
        /// Ticks the mind, calling process if it is time.
        /// </summary>
        /// <returns>Whether process was called.</returns>
        public virtual bool tick() {
            if (Time.TotalTime > nextRefreshAt) {
                nextRefreshAt = Time.TotalTime + refresh;
                process();
                return true;
            }

            return false;
        }
    }
}