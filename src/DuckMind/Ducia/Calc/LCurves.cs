using XNez.GUtils.Misc;

namespace Ducia.Calc {
    public static class LCurves {
        /// <summary>
        /// x^n function, but absolute value on negative x
        /// </summary>
        /// <param name="v"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static float symmetricPow(float v, float e) {
            if (v >= 0) return GMathf.pow(v, e);
            return -GMathf.abs(GMathf.pow(v, e));
        }

        /// <summary>
        /// the advantage [-1,1] given a ratio [0, inf), where <1 is advantage
        /// </summary>
        /// <param name="ratio"></param>
        /// <param name="tightness"></param>
        /// <returns></returns>
        public static float ratioAdvantage(float ratio, float tightness) {
            // this assumes that <1 is advantage and >1 is disadvantage
            // adv(x) = f_rdw(log_h(x))
            var loghx = GMathf.log(ratio, tightness);
            // f_rdw(x) = 2* ((1)/(1+ ( 1*e^(1x) )  ))
            var fdrw = 2 * ((1) / (1 + (1 * GMathf.exp(1 * loghx)))) - 1;

            return fdrw;
        }

        /// <summary>
        /// models a diminishing return function f(x)=A*e^(-rx), outputs [0,1] given an input value x 
        /// </summary>
        /// <param name="baseValue"></param>
        /// <param name="falloff"></param>
        /// <returns></returns>
        public static float diminishingReturns(float x, float baseValue, float falloff) {
            return baseValue * GMathf.exp(-falloff * x);
        }
    }
}