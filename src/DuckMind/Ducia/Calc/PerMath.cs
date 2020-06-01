using XNez.GUtils.Misc;

namespace Ducia.Calc {
    /// <summary>
    /// Personality math utilities
    /// </summary>
    public static class PerMath {
        /// <summary>
        ///     Given v, take (min * v) and add ((max-min) * d)
        ///     Result is then clamped to [min, max]
        ///     Useful for scaling a value between a min and max value
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float twoSegment(float v, float d, float min, float max, bool clamp = false) {
            var s1 = v * min;
            var b = max - min;
            var r = s1 + b * d;
            if (clamp) r = GMathf.clamp(r, min, max);
            return r;
        }

        /// <summary>
        /// rescale from [-1,1] to [0,1]
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static float map11to01(float v) {
            return GMathf.map01(v, -1f, 1f);
        }
    }
}