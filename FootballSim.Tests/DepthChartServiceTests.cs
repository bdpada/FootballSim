using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class DepthChartServiceTests
{
    [Fact]
    public void CreateDefaultDepthChart_GroupsByPositionAndOrdersByRatingThenName()
    {
        var low = TestData.Player("low", overall: 60);
        var high = TestData.Player("high", overall: 90);
        var tie = TestData.Player("tie", overall: 90);
        high.LastName = tie.LastName = "Same";
        high.FirstName = "Aaron";
        tie.FirstName = "Zoe";
        var receiver = TestData.Player("receiver", PlayerPosition.WR);
        var service = new DepthChartService();

        var chart = service.CreateDefaultDepthChart([low, tie, receiver, high]);

        Assert.Equal(new[] { "high", "tie", "low" }, chart.GetPlayerIdsAtPosition(PlayerPosition.QB));
        Assert.Equal(new[] { "receiver" }, chart.GetPlayerIdsAtPosition(PlayerPosition.WR));
        Assert.Empty(chart.GetPlayerIdsAtPosition(PlayerPosition.K));
    }

    [Theory]
    [InlineData(PlayerPosition.QB, 1)]
    [InlineData(PlayerPosition.RB, 1)]
    [InlineData(PlayerPosition.WR, 3)]
    [InlineData(PlayerPosition.TE, 1)]
    [InlineData(PlayerPosition.C, 1)]
    [InlineData(PlayerPosition.G, 2)]
    [InlineData(PlayerPosition.T, 2)]
    [InlineData(PlayerPosition.DE, 2)]
    [InlineData(PlayerPosition.DT, 2)]
    [InlineData(PlayerPosition.ILB, 2)]
    [InlineData(PlayerPosition.OLB, 2)]
    [InlineData(PlayerPosition.CB, 2)]
    [InlineData(PlayerPosition.S, 2)]
    [InlineData(PlayerPosition.K, 1)]
    public void GetStarters_ReturnsRequiredHealthyPlayersInDepthOrder(PlayerPosition position, int count)
    {
        var roster = Enumerable.Range(0, 5).Select(i => TestData.Player($"p{i}", position, 90 - i)).ToList();
        roster[0].ApplyInjury(2);
        var service = new DepthChartService();
        var chart = service.CreateDefaultDepthChart(roster);

        var starters = service.GetStarters(chart, roster, position);

        Assert.Equal(roster.Skip(1).Take(count), starters);
        Assert.All(starters, p => Assert.False(p.IsInjured));
        Assert.True(service.HasEnoughHealthyPlayers(chart, roster, position));
    }

    [Fact]
    public void AutoFixAllPositions_MovesInjuredStarterBehindHealthyBackupAndIsIdempotent()
    {
        var starter = TestData.Player("starter", overall: 90);
        starter.ApplyInjury(3);
        var backup = TestData.Player("backup", overall: 60);
        Player[] roster = [starter, backup];
        var service = new DepthChartService();
        var chart = service.CreateDefaultDepthChart(roster);
        Assert.True(service.HasInjuredPlayersAboveHealthyStarters(chart, roster, PlayerPosition.QB));

        var changed = service.AutoFixAllPositions(chart, roster);

        Assert.True(changed);
        Assert.Equal(new[] { "backup", "starter" }, chart.GetPlayerIdsAtPosition(PlayerPosition.QB));
        Assert.False(service.HasInjuredPlayersAboveHealthyStarters(chart, roster, PlayerPosition.QB));
        Assert.False(service.AutoFixAllPositions(chart, roster));
        Assert.Equal(3, starter.InjuryWeeksRemaining);
    }

    [Fact]
    public void GetStarters_AllPlayersInjuredReturnsEmptyAndReportsShortage()
    {
        var player = TestData.Player();
        player.ApplyInjury(2);
        var service = new DepthChartService();
        var chart = service.CreateDefaultDepthChart([player]);

        var starters = service.GetStarters(chart, [player], PlayerPosition.QB);

        Assert.Empty(starters);
        Assert.False(service.HasEnoughHealthyPlayers(chart, [player], PlayerPosition.QB));
        Assert.False(service.AutoFixPosition(chart, [player], PlayerPosition.K));
    }
}
