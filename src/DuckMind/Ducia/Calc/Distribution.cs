using System.Collections.Generic;
using System.Linq;
using XNez.GUtils.Misc;

namespace Ducia.Calc {
    public class Distribution {
        public static float exponentialDf(float x, float m) => (float) GMathf.exp(-x * m);

        /// <summary>
        /// selects a random value using a normal distribution
        /// </summary>
        /// <param name="u">mean value</param>
        /// <param name="s">standard deviation</param>
        /// <returns></returns>
        public static float normalRand(float u, float s) {
            // https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
            // https://stackoverflow.com/a/218600
            // i honestly have no idea how this works
            var u1 = 1.0f - GRand.nextFloat();
            var u2 = 1.0f - GRand.nextFloat();
            var dst = GMathf.sqrt(-2f * GMathf.log(u1))
                                * GMathf.sin(2f * GMathf.PI * u2);
            var v =
                u + s * dst;
            return v;
        }

        public static double[] summarizeDistribution(IEnumerable<double> values) {
            var sorted = values.OrderBy(x => x).ToArray();
            var avg = sorted.Average();
            var min = sorted[0];
            var max = sorted[sorted.Length - 1];
            var q1 = sorted[(int) (sorted.Length * 0.25)];
            var q2 = sorted[(int) (sorted.Length * 0.50)];
            var q3 = sorted[(int) (sorted.Length * 0.75)];
            return new double[] {avg, min, q1, q2, q3, max};
        }
    }
}