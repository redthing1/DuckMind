using System;

namespace Ducia.Calc {
    public class Rng {
        private readonly Random rng;

        public Rng(int seed) {
            rng = new Random(seed);
        }

        public int next() {
            return rng.Next();
        }

        public int next(int min, int max) {
            return rng.Next(min, max);
        }

        public float nextFloat() {
            return (float)rng.NextDouble();
        }
    }
}