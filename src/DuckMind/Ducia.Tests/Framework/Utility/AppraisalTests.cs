using Ducia.Framework.Utility;
using Ducia.Framework.Utility.Considerations;
using Xunit;

namespace Ducia.Tests.Framework.Utility; 

public class AppraisalTests {
    [Fact]
    public void canTransformAppraisals() {
        var carp1 = new MagicCarpet(6, 0);

        // raw score
        var basic = new BalloonAppraisal(carp1);
        Assert.Equal(0.6f, basic.transformedScore(), 4);

        var clamped = new BalloonAppraisal(carp1).clamp(0.3f);
        Assert.Equal(0.3f, clamped.transformedScore(), 4);

        var scaled = new BalloonAppraisal(carp1).scale(0.1f);
        Assert.Equal(0.06f, scaled.transformedScore(), 4);

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
        var floatConsid = new ThresholdSumConsideration<MagicCarpet>(() => { }, 0.5f);
        floatConsid.addAppraisal(new BalloonAppraisal(carpet));
        floatConsid.addAppraisal(new WeightsAppraisal(carpet).negate());

        var score = floatConsid.score();
        Assert.Equal(0f, score, 4);
    }

    [Fact]
    public void canScoreConsiderationsWithTransformedAppraisals() {
        var carpet = new MagicCarpet(4, 8);
        var floatConsid = new SumConsideration<MagicCarpet>(() => { });
        floatConsid.addAppraisal(new BalloonAppraisal(carpet));
        floatConsid.addAppraisal(new WeightsAppraisal(carpet).clamp(0.6f).negate());

        var score = floatConsid.score();
        Assert.Equal(-0.2f, score, 4);
    }

    private class MagicCarpet {
        /// <summary>
        ///     the maximum amount of force able to be applied by balloons or weights
        /// </summary>
        public const int MAX_FORCE = 10;

        /// <summary>
        ///     balloons make the magic carpet rise
        /// </summary>
        public readonly int balloons;

        /// <summary>
        ///     weights make the magic carpet sink
        /// </summary>
        public readonly int weights;

        public MagicCarpet(int balloons, int weights) {
            this.balloons = balloons;
            this.weights = weights;
        }
    }

    private class BalloonAppraisal : Appraisal<MagicCarpet> {
        public BalloonAppraisal(MagicCarpet context) : base(context) { }

        public override float score() {
            return (float)context.balloons / MagicCarpet.MAX_FORCE;
        }
    }

    private class WeightsAppraisal : Appraisal<MagicCarpet> {
        public WeightsAppraisal(MagicCarpet context) : base(context) { }

        public override float score() {
            return (float)context.weights / MagicCarpet.MAX_FORCE;
        }
    }
}