using System;

namespace Ducia.Framework.Utility.Considerations {
    /// <summary>
    /// Adds all appraisals. Each must score above the threshold
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThresholdConsideration<T> : Consideration<T> {
        private float threshold;

        public ThresholdConsideration(Action action, float threshold, string? tag = null) : base(action, tag) {
            this.threshold = threshold;
        }

        public override float score() {
            var sum = 0f;
            foreach (var appraisal in appraisals) {
                var score = scoreAppraisal(appraisal);
                if (score < threshold) return 0;
                sum += score;
            }

            return sum;
        }
    }
}