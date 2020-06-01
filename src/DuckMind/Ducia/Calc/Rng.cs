using System;

namespace Ducia.Calc {
    public class Rng {
        private Random rng;

        public Rng(int seed) {
            rng = new Random(seed);
        }

        public int next() => rng.Next();
        public int next(int min, int max) => rng.Next(min, max);
        public float nextFloat() => (float) rng.NextDouble();
    }
}