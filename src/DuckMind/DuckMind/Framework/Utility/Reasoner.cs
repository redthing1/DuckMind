using System;
using System.Collections.Generic;
using DuckMind.Framework.Utility.Considerations;

namespace DuckMind.Framework.Utility {
    public class Reasoner<T> {
        protected List<Consideration<T>> considerations = new List<Consideration<T>>();
        private static readonly Random random = new Random();
        public ScoreType scoreType = ScoreType.Raw;

        public enum ScoreType {
            Raw,
            Normalized
        }

        public void addConsideration(Consideration<T> consideration) {
            considerations.Add(consideration);
        }

        private float getScore(Consideration<T> consideration) {
            switch (scoreType) {
                case ScoreType.Raw: return consideration.score();
                case ScoreType.Normalized: return consideration.normalizedScore();
            }

            return 0;
        }

        public Dictionary<Consideration<T>, float> execute() {
            var results = new Dictionary<Consideration<T>, float>();
            foreach (var consideration in considerations) {
                var score = getScore(consideration);
                results[consideration] = score;
            }

            return results;
        }

        public Consideration<T> choose() {
            var results = execute();
            return choose(results);
        }

        public Consideration<T> choose(Dictionary<Consideration<T>, float> results) {
            var max = default(KeyValuePair<Consideration<T>, float>);
            foreach (var result in results) {
                if (max.Key == null || result.Value > max.Value) {
                    max = result;
                }
            }

            return max.Key;
        }

        // public Consideration<T> chooseFuzzy(float fuzzy) {
        //     var results = execute();
        //     var candidates = results.OrderByDescending(x => x.Item2).Take((int) Math.Ceiling(fuzzy * results.Count)).ToList();
        //     return candidates[(int) (random.NextDouble() * candidates.Count)].Item1;
        // }
    }
}