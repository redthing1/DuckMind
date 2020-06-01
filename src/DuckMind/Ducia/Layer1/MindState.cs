using System.Collections.Concurrent;

namespace Ducia {
    public abstract class MindState {
        public int ticks = 0;
        public float totalTime = 0f;
        
        public ConcurrentQueue<MindSignal> signalQueue = new ConcurrentQueue<MindSignal>(); // signals to be processed
        
        public virtual void tick(float elapsed) {
            ticks++;
            totalTime += elapsed;
        }
    }
}