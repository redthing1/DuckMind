using Ducia.Calc;
using XNez.GUtils.Misc;

namespace Ducia.Cogs {
    public abstract class Personality {
        public abstract float[] vec { get; }
        
        public float mult(float[] weights) {
            var nvec = GMathf.normVec(vec); // normalized personality vector
            return GMathf.dot(nvec, weights);
        }
        
        // normalize personality component from [-1,1] to [0,1]
        // inverse normalize from [0,1] to [-1,1]
        public float map11(float v) => (v * 2) - 1;

        public static float normalRand(float u, float s) {
            return GMathf.clamp(Distribution.normalRand(u, s), -1f, 1f);
        }
    }
}