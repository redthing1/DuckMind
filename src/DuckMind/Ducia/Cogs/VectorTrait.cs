using XNez.GUtils.Misc;

namespace Ducia.Cogs {
    public static class VectorTrait {
        /// <summary>
        /// calculate the value of a trait for a personality
        /// normalizes both the weight vector and the personality vector
        /// </summary>
        /// <param name="weights">trait weights</param>
        /// <param name="p">personality</param>
        /// <returns></returns>
        public static float normalizedValue(float[] weights, Personality p) {
            var normalizedWeights = GMathf.normVec(weights); // normalized weight vec
            var result = p.mult(normalizedWeights);
            return result;
        }

        /// <summary>
        /// computes the raw dot product of the weight vector and the personality vector
        /// without normalization
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float rawValue(float[] weights, Personality p) {
            return p.multRaw(weights);
        }

        /// <summary>
        /// second (or higher) order trait calculation
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="traits"></param>
        /// <returns></returns>
        public static float trait2(float[] weights, float[] traits) {
            var normalizedWeights = GMathf.normVec(weights); // normalize weights
            var normalizedTraits = GMathf.normVec(traits); // normalize trait combination
            var result = GMathf.dot(normalizedWeights, normalizedTraits);
            return result;
        }
    }
}