using System;
using System.Collections.Generic;

namespace Ducia.Framework.Utility.Considerations {
    public abstract class Consideration<T> {
        public Action action;
        protected List<Appraisal<T>> appraisals = new List<Appraisal<T>>();
        public virtual string? tag { get; }
        public Dictionary<Appraisal<T>, float> lastScores = new Dictionary<Appraisal<T>, float>();

        public Consideration(Action action, string? tag = null) {
            this.action = action;
            this.tag = tag;
        }

        public void addAppraisal(Appraisal<T> appraisal) {
            appraisals.Add(appraisal);
        }

        protected float scoreAppraisal(Appraisal<T> appraisal) {
            var score = appraisal.transformedScore();

            lastScores[appraisal] = score; // log last score

            return score;
        }

        public abstract float score();

        public float normalizedScore() {
            return score() / appraisals.Count;
        }
    }
}