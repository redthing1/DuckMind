using System;

namespace Ducia.Framework.Utility.Considerations {
    /// <summary>
    /// Adds all appraisals. The total must score above the threshold
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThresholdSumConsideration<T> : Consideration<T> {
        private float threshold;

        public ThresholdSumConsideration(Action action, float threshold, string? tag = null) : base(action, tag) {
            this.threshold = threshold;
        }

        public override float score() {
            var sum = 0f;
            foreach (var appraisal in appraisals) {
                sum += scoreAppraisal(appraisal);
            }

            if (sum < threshold) sum = 0;
            return sum;
        }
    }
}