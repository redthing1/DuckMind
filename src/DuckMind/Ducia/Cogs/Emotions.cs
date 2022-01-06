using System;

namespace Ducia.Cogs; 

public abstract class Emotions {
    public abstract float[] vec { get; }
    public virtual float falloff { get; } = 0.9f;

    /// <summary>
    ///     update the emotions. they will fade with time, exponentially tending toward zero
    /// </summary>
    public void tick() {
        for (var i = 0; i < vec.Length; i++) vec[i] = falloff * vec[i];
    }

    /// <summary>
    ///     resets all emotions to neutral values
    /// </summary>
    public void reset() {
        for (var i = 0; i < vec.Length; i++) vec[i] = 0f;
    }

    /// <summary>
    ///     spikes an emotion to a given level if more intense than current emotion.
    ///     does nothing if the spike is less intense than the current emotion.
    /// </summary>
    /// <param name="emotion"></param>
    /// <param name="val"></param>
    protected void spike(ref float emotion, float val) {
        if (Math.Abs(val) > Math.Abs(emotion)) emotion = val;
    }
}