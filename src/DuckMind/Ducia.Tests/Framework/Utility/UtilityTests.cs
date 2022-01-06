using Xunit;

namespace Ducia.Tests.Framework.Utility; 

public class UtilityTests {
    public CakeGame game;

    public UtilityTests() {
        game = new CakeGame();
    }

    public Baker baker => game.baker;

    [Fact]
    public void canExecuteReasoner() {
        var results = baker.think();
        Assert.NotEmpty(results);
    }

    [Fact]
    public void canWinCakeGame() {
        Assert.True(game.cakesBaked == 0);
        var win = game.run(50);
        Assert.True(win);
        Assert.True(game.cakesBaked > 0);
    }

    [Fact]
    public void canWinCakeGameManyIterations() {
        Assert.True(game.cakesBaked == 0);
        var win = game.run(10000);
        Assert.True(win);
        Assert.True(game.cakesBaked > 0);
    }
}