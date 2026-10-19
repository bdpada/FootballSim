using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class PlayerOverallCalculatorTests
{
    [Theory]
    [InlineData(PlayerPosition.QB, 78)]
    [InlineData(PlayerPosition.RB, 52)]
    [InlineData(PlayerPosition.WR, 40)]
    [InlineData(PlayerPosition.TE, 36)]
    [InlineData(PlayerPosition.C, 40)]
    [InlineData(PlayerPosition.G, 40)]
    [InlineData(PlayerPosition.T, 40)]
    [InlineData(PlayerPosition.DE, 65)]
    [InlineData(PlayerPosition.DT, 65)]
    [InlineData(PlayerPosition.ILB, 68)]
    [InlineData(PlayerPosition.OLB, 68)]
    [InlineData(PlayerPosition.CB, 60)]
    [InlineData(PlayerPosition.S, 60)]
    [InlineData(PlayerPosition.K, 80)]
    public void Calculate_UsesPositionSpecificWeights(PlayerPosition position, int expected)
    {
        var player = TestData.Player(position: position);

        var overall = PlayerOverallCalculator.Calculate(player);

        Assert.Equal(expected, overall);
    }

    [Theory]
    [InlineData(-100, 0)]
    [InlineData(0, 0)]
    [InlineData(99, 99)]
    [InlineData(200, 99)]
    public void Calculate_ClampsRatingsForEveryPosition(int attribute, int expected)
    {
        foreach (var position in Enum.GetValues<PlayerPosition>())
        {
            var player = TestData.Player(position: position);
            player.Speed = player.Strength = player.Awareness = player.Stamina = player.Durability =
                player.ThrowAccuracy = player.ThrowPower = player.Catching = player.RouteRunning =
                player.Blocking = player.Tackling = player.Coverage = player.Kicking = attribute;

            var overall = PlayerOverallCalculator.Calculate(player);

            Assert.Equal(expected, overall);
        }
    }

    [Fact]
    public void Calculate_IdenticalAttributesReturnSameValueWithoutMutatingPlayer()
    {
        var first = TestData.Player("first");
        var second = TestData.Player("second");

        var result = PlayerOverallCalculator.Calculate(first);

        Assert.Equal(result, PlayerOverallCalculator.Calculate(second));
        Assert.Equal(result, PlayerOverallCalculator.Calculate(first));
        Assert.Equal(70, first.Overall);
        Assert.Equal(90, first.ThrowAccuracy);
    }
}
