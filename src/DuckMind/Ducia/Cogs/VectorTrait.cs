using XNez.GUtils.Misc;

namespace Ducia.Cogs {
    public static class VectorTrait {
        /// <summary>
        /// calculate the value of a trait for a personality
        /// </summary>
        /// <param name="weights">trait weights</param>
        /// <param name="p">personality</param>
        /// <returns></returns>
        public static float value(float[] weights, Personality p) {
            var nweights = GMathf.normVec(weights); // normalized weight vec
            var result = p.mult(nweights);
            return result;
        }

        /// <summary>
        /// second-order trait calculation
        /// </summary>
        /// <param name="weights"></param>
        /// <param name="traits"></param>
        /// <returns></returns>
        public static float trait2(float[] weights, float[] traits) {
            var nvec = GMathf.normVec(weights); // normalize weights
            var nTraits = GMathf.normVec(traits); // normalize trait combination
            var result = GMathf.dot(nvec, nTraits);
            return result;
        }
    }
}