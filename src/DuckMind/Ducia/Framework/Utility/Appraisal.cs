using System;
using System.Collections.Generic;
using System.Linq;
using Ducia.Primer;

namespace Ducia.Framework.Utility {
    public abstract class Appraisal<T> {
        protected T context;

        /// <summary>
        /// a utility to attach a "postprocess/transform" function to the score
        /// </summary>
        private List<Func<float, float>> transforms = new List<Func<float, float>>();

        public Appraisal(T context) {
            this.context = context;
        }

        public abstract float score();

        public float transformedScore() {
            var val = score();
            if (transforms.Count > 0) {
                var v = val;
                for (var i = 0; i < transforms.Count; i++) {
                    v = transforms[i].Invoke(v);
                }

                val = v;
            }

            return val;
        }

        public Appraisal<T> negate() {
            transforms.Add(v => -v);
            return this;
        }

        public Appraisal<T> inverse() {
            transforms.Add(v => (1f - v));
            return this;
        }

        public Appraisal<T> clamp(float limit) {
            transforms.Add(v => Mathf.clamp(v, 0, limit));
            return this;
        }

        public Appraisal<T> scale(float scale) {
            transforms.Add(v => scale * v);
            return this;
        }
    }
}