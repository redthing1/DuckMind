using System.Collections.Concurrent;

namespace Ducia {
    /// <summary>
    /// represents all data that is considered "state" or "working" information of the mind.
    /// it can include things like caches for senses and observations
    /// and plans and working memory
    /// </summary>
    public abstract class MindState {
        protected int ticks = 0;
        public float totalTime = 0f;
        
        public ConcurrentQueue<MindSignal> signalQueue = new ConcurrentQueue<MindSignal>(); // signals to be processed
        
        /// <summary>
        /// called by the Mind, representing elapsed time
        /// </summary>
        /// <param name="elapsed"></param>
        public virtual void tick(float elapsed) {
            ticks++;
            totalTime += elapsed;
        }
    }
}