using Xunit;

namespace Ducia.Tests.Framework.Utility {
    public class UtilityTests {
        public CakeGame game;
        public Baker baker => game.baker;

        public UtilityTests() {
            game = new CakeGame();
        }

        [Fact]
        public void canExecuteReasoner() {
            var results = baker.think();
            Assert.NotEmpty(results);
        }

        [Fact]
        public void canWinCakeGame() {
            Assert.True(game.cakesBaked == 0);
            game.run(50);
            Assert.True(game.cakesBaked > 0);
        }
    }
}