using System;
using System.Collections.Generic;
using System.Linq;
using XNez.GUtils.Misc;

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
            if (transforms.Any()) {
                val = transforms.Aggregate(val, (last, func) => func(last));
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
            transforms.Add(v => GMathf.clamp(v, 0, limit));
            return this;
        }
    }
}