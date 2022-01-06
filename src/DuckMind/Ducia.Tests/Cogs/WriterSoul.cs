using Ducia.Calc;
using Ducia.Cogs;

namespace Ducia.Tests.Cogs; 

public class WriterSoul : Sentient<WriterSoul.Personality, WriterSoul.Traits, WriterSoul.Emotions> {
    public class Personality : Ducia.Cogs.Personality {
        /// <summary>
        ///     creativity
        /// </summary>
        public float C;

        /// <summary>
        ///     extraversion
        /// </summary>
        public float E;

        public Personality() { }

        public Personality(float e, float c) {
            E = e;
            C = c;
        }

        public override float[] vec => new[] { E, C };

        public static Personality makeRandom() {
            // generate personalities along a normal distribution
            return new Personality(
                PerMath.clamp11(normalRand(0.2f, 0.6f)), // extraversion distribution
                PerMath.clamp11(normalRand(-0.2f, 0.6f)) // creativity distribution
            );
        }
    }

    public class Traits : Traits<Personality> {
        public static float[] vec_productivity = { 0.5f, -0.2f };
        public static float[] vec_popularity = { 0.9f, 0.4f };
        public float popularity;

        public float productivity;

        public override void calculate(Personality ply) {
            productivity = VectorTrait.rawValue(vec_productivity, ply);
            popularity = VectorTrait.normalizedValue(vec_popularity, ply);
        }
    }

    public class Emotions : Ducia.Cogs.Emotions {
        // emotions: [inspired, happy]
        public override float[] vec { get; } = { 0f, 0f };
        public override float falloff => 0.9f;

        public ref float inspired => ref vec[0];
        public ref float happy => ref vec[1];
    }
}