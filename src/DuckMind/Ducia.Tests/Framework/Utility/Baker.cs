using Ducia.Framework.Utility;
using Ducia.Framework.Utility.Considerations;

namespace Ducia.Tests.Framework.Utility {
    public partial class Baker {
        /// <summary>
        /// the utility reasoner
        /// </summary>
        public Reasoner<CakeGame> reasoner;

        /// <summary>
        /// the game state
        /// </summary>
        public CakeGame game;

        public Baker(CakeGame game) {
            buildReasoner();
            this.game = game;
        }

        private void buildReasoner() {
            reasoner = new Reasoner<CakeGame>();
            reasoner.scoreType = Reasoner<CakeGame>.ScoreType.Normalized;

            var sleepConsid = new ThresholdSumConsideration<CakeGame>(game.sleepBed, 0.7f, "sleep");
            sleepConsid.addAppraisal(new Sleepy(game));
            sleepConsid.addAppraisal(new Backlogged(game).clamp(0.5f).inverse());
            reasoner.addConsideration(sleepConsid);

            var bakeConsid = new SumConsideration<CakeGame>(game.bakeCake, "bake");
            bakeConsid.addAppraisal(new Backlogged(game));
            reasoner.addConsideration(bakeConsid);

            var shopConsid = new SumConsideration<CakeGame>(game.buyFlour, "shop");
            shopConsid.addAppraisal(new LowFlour(game));
            reasoner.addConsideration(shopConsid);
        }

        public void act() {
            var results = reasoner.execute();
            // choose the highest ranked option
            var chosen = reasoner.choose(results);
            // execute the action
            chosen.action();
        }
    }
}