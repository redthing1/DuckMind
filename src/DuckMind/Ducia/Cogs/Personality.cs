using Ducia.Calc;
using Ducia.Primer;

namespace Ducia.Cogs; 

public abstract class Personality {
    public abstract float[] vec { get; }

    /// <summary>
    ///     dot product of normalized vec and weights
    /// </summary>
    /// <param name="weights"></param>
    /// <returns></returns>
    public float mult(float[] weights) {
        var nvec = Mathf.normVec(vec); // normalized personality vector
        return Mathf.dot(nvec, weights);
    }

    /// <summary>
    ///     dot product of raw vec and weights, without normalization
    /// </summary>
    /// <param name="weights"></param>
    /// <returns></returns>
    public float multRaw(float[] weights) {
        return Mathf.dot(vec, weights);
    }

    public static float normalRand(float u, float s) {
        return Mathf.clamp(Distribution.normalRand(u, s), -1f, 1f);
    }
}