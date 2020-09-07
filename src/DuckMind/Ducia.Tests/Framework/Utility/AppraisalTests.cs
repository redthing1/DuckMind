using Ducia.Framework.Utility;
using Ducia.Framework.Utility.Considerations;
using Xunit;

namespace Ducia.Tests.Framework.Utility {
    public class AppraisalTests {
        private ThresholdSumConsideration<MagicCarpet> floatConsideration;

        class MagicCarpet {
            /// <summary>
            /// the maximum amount of force able to be applied by balloons or weights
            /// </summary>
            public const int MAX_FORCE = 10;

            /// <summary>
            /// balloons make the magic carpet rise
            /// </summary>
            public int balloons = 0;

            /// <summary>
            /// weights make the magic carpet sink
            /// </summary>
            public int weights = 0;

            public MagicCarpet(int balloons, int weights) {
                this.balloons = balloons;
                this.weights = weights;
            }
        }

        class BalloonAppraisal : Appraisal<MagicCarpet> {
            public BalloonAppraisal(MagicCarpet context) : base(context) { }

            public override float score() {
                return (float) context.balloons / MagicCarpet.MAX_FORCE;
            }
        }

        class WeightsAppraisal : Appraisal<MagicCarpet> {
            public WeightsAppraisal(MagicCarpet context) : base(context) { }

            public override float score() {
                return (float) context.weights / MagicCarpet.MAX_FORCE;
            }
        }

        [Fact]
        public void canTransformAppraisals() {
            var carp1 = new MagicCarpet(6, 0);

            // raw score
            var basic = new BalloonAppraisal(carp1);
            Assert.Equal(0.6f, basic.transformedScore(), 4);

            var clamped = new BalloonAppraisal(carp1).clamp(0.3f);
            Assert.Equal(0.3f, clamped.transformedScore(), 4);

            var inverted = new BalloonAppraisal(carp1).inverse();
            Assert.Equal(0.4f, inverted.transformedScore(), 4);

            var negated = new BalloonAppraisal(carp1).negate();
            Assert.Equal(-0.6f, negated.transformedScore(), 4);

            var clampedNegated = new BalloonAppraisal(carp1).clamp(0.3f).negate();
            Assert.Equal(-0.3f, clampedNegated.transformedScore(), 4);
        }

        [Fact]
        public void canScoreConsideration() {
            var carpet = new MagicCarpet(2, 2);
            floatConsideration = new ThresholdSumConsideration<MagicCarpet>(() => { }, 0.5f);
            floatConsideration.addAppraisal(new BalloonAppraisal(carpet));
            floatConsideration.addAppraisal(new WeightsAppraisal(carpet).negate());

            var score = floatConsideration.score();
            Assert.Equal(0f, score);
        }
    }
}