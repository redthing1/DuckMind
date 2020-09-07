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
            game.run(50);
        }
    }
}