using System;
using System.Collections.Generic;
using Ducia.Framework.Utility.Considerations;

namespace Ducia.Framework.Utility {
    public class Reasoner<T> {
        protected List<Consideration<T>> considerations = new List<Consideration<T>>();
        private static readonly Random random = new Random();
        public ScoreType scoreType = ScoreType.Raw;
        
        /// <summary>
        /// whether to enable internal tracing
        /// </summary>
        public static bool trace = false;

        public enum ScoreType {
            /// <summary>
            /// use raw sum of appraisals as the score
            /// </summary>
            Raw,
            /// <summary>
            /// normalize the sum of the appraisals to the interval [0, 1]
            /// </summary>
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
            execute(results);
            return results;
        }

        /// <summary>
        /// runs the reasoner, and stores the results in the provided dictionary
        /// </summary>
        /// <param name="results"></param>
        public void execute(Dictionary<Consideration<T>, float> results) {
            results.Clear();
            foreach (var consideration in considerations) {
                var score = getScore(consideration);
                results[consideration] = score;
            }
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