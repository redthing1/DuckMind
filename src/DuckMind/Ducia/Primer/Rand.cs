using System;
using System.Collections.Generic;

namespace Ducia.Primer {
    public static class Rand {
        private static int _seed = Environment.TickCount;
        public static Random random = new Random(_seed);


        /// <summary>
        ///     returns current seed value
        /// </summary>
        /// <returns>Seed.</returns>
        public static int getSeed() {
            return _seed;
        }


        /// <summary>
        ///     resets rng with new seed
        /// </summary>
        /// <param name="seed">Seed.</param>
        public static void setSeed(int seed) {
            _seed = seed;
            random = new Random(_seed);
        }


        /// <summary>
        ///     returns a random float between 0 (inclusive) and 1 (exclusive)
        /// </summary>
        /// <returns>The float.</returns>
        public static float nextFloat() {
            return (float)random.NextDouble();
        }


        /// <summary>
        ///     returns a random float between 0 (inclusive) and max (exclusive)
        /// </summary>
        /// <returns>The float.</returns>
        /// <param name="max">Max.</param>
        public static float nextFloat(float max) {
            return (float)random.NextDouble() * max;
        }


        /// <summary>
        ///     returns a random int between 0 (inclusive) and max (exclusive)
        /// </summary>
        /// <returns>The float.</returns>
        /// <param name="max">Max.</param>
        public static int nextInt(int max) {
            return random.Next(max);
        }


        /// <summary>
        ///     Returns a random integer between min (inclusive) and max (exclusive)
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int range(int min, int max) {
            return random.Next(min, max);
        }


        /// <summary>
        ///     Returns a random float between min (inclusive) and max (exclusive)
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float range(float min, float max) {
            return min + nextFloat(max - min);
        }


        /// <summary>
        ///     returns a random float between -1 and 1
        /// </summary>
        /// <returns>The one to one.</returns>
        public static float minusOneToOne() {
            return nextFloat(2f) - 1f;
        }


        /// <summary>
        ///     returns true if the next random is less than percent. Percent should be between 0 and 1
        /// </summary>
        /// <param name="percent">Percent.</param>
        public static bool chance(float percent) {
            return nextFloat() < percent;
        }


        /// <summary>
        ///     returns true if the next random is less than value. Value should be between 0 and 100.
        /// </summary>
        /// <param name="value">Value.</param>
        public static bool chance(int value) {
            return nextInt(100) < value;
        }


        /// <summary>
        ///     randomly returns one of the given values
        /// </summary>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T choose<T>(T first, T second) {
            if (nextInt(2) == 0)
                return first;
            return second;
        }


        /// <summary>
        ///     randomly returns one of the given values
        /// </summary>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T choose<T>(T first, T second, T third) {
            switch (nextInt(3)) {
                case 0:
                    return first;
                case 1:
                    return second;
                default:
                    return third;
            }
        }


        /// <summary>
        ///     randomly returns one of the given values
        /// </summary>
        /// <param name="first">First.</param>
        /// <param name="second">Second.</param>
        /// <param name="third">Third.</param>
        /// <param name="fourth">Fourth.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T choose<T>(T first, T second, T third, T fourth) {
            switch (nextInt(4)) {
                case 0:
                    return first;
                case 1:
                    return second;
                case 2:
                    return third;
                default:
                    return fourth;
            }
        }

        public static T choose<T>(List<T> list) {
            return list[nextInt(list.Count)];
        }
    }
}