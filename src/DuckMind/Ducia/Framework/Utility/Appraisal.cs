using System;

namespace Ducia.Framework.Utility {
    public abstract class Appraisal<T> {
        protected T context;

        public Appraisal(T context) {
            this.context = context;
        }

        public abstract float score();

        /// <summary>
        /// a utility to attach a "postprocess/transform" function to the score
        /// </summary>
        public Func<float, float> transform;

        public Appraisal<T> inverse() {
            transform = v => (1f - v);
            return this;
        }
    }
}