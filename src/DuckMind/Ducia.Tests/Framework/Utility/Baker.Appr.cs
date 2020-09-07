using Ducia.Framework.Utility;
using XNez.GUtils.Misc;

namespace Ducia.Tests.Framework.Utility {
    public partial class Baker {
        /// <summary>
        /// how sleepy we are
        /// </summary>
        class Sleepy : Appraisal<CakeGame> {
            public Sleepy(CakeGame context) : base(context) { }

            public override float score() {
                return GMathf.pow(context.fatigue, 1.5f);
            }
        }

        /// <summary>
        /// how much pending work we have
        /// </summary>
        class Backlogged : Appraisal<CakeGame> {
            public Backlogged(CakeGame context) : base(context) { }

            public override float score() {
                // the point where we consider ourself fully backlogged
                var bigBacklog = 4f;
                var backlogProportion = context.orders / bigBacklog;
                // clamp
                return GMathf.clamp01(backlogProportion);
            }
        }

        /// <summary>
        /// how badly we need to refill flour
        /// </summary>
        class LowFlour : Appraisal<CakeGame> {
            public LowFlour(CakeGame context) : base(context) { }

            public override float score() {
                // how many cakes we can bake with the remaining flour
                var bakeableCakes = context.flour / CakeGame.FLOUR_PER_CAKE;
                // where we're really getting close to running out
                var superLow = 2f;
                if (bakeableCakes <= superLow) return 1; // max activation
                // distance  to super low
                var dist = bakeableCakes - superLow;
                // the further we are, the lower the activation 
                var distProp = 1 / dist;
                // scale on square root curve
                return GMathf.pow(distProp, 0.5f);
            }
        }
    }
}