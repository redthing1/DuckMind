using Ducia.Calc;
using XNez.GUtils.Misc;

namespace Ducia.Cogs {
    public abstract class Personality {
        public abstract float[] vec { get; }

        /// <summary>
        /// dot product of normalized vec and weights
        /// </summary>
        /// <param name="weights"></param>
        /// <returns></returns>
        public float mult(float[] weights) {
            var nvec = GMathf.normVec(vec); // normalized personality vector
            return GMathf.dot(nvec, weights);
        }

        /// <summary>
        /// dot product of raw vec and weights, without normalization
        /// </summary>
        /// <param name="weights"></param>
        /// <returns></returns>
        public float multRaw(float[] weights) {
            return GMathf.dot(vec, weights);
        }

        public static float normalRand(float u, float s) {
            return GMathf.clamp(Distribution.normalRand(u, s), -1f, 1f);
        }
    }
}