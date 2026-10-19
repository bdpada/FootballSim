using FootballSim.Core.Models;
using FootballSim.Core.Services;

namespace FootballSim.Tests;

public class TransactionServiceTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SignFreeAgent_TransfersOwnershipAndAddsToDepthChart(bool existingChart)
    {
        var league = TestData.League();
        var team = league.Teams[0];
        var player = TestData.Player(teamId: "");
        league.FreeAgents.Add(player);
        if (existingChart) team.DepthChart = new();
        var service = new TransactionService();

        var success = service.SignFreeAgent(league, team, player.Id, out var message);

        Assert.True(success, message);
        Assert.Same(player, Assert.Single(team.Roster));
        Assert.Empty(league.FreeAgents);
        Assert.Equal(team.Id, player.TeamId);
        Assert.Contains(player.Id, team.DepthChart!.GetPlayerIdsAtPosition(player.Position));
    }

    [Fact]
    public void CutPlayer_RemovesFromRosterAndDepthChartAndReturnsToFreeAgents()
    {
        var league = TestData.League();
        var team = league.Teams[0];
        var player = TestData.Player();
        team.Roster.Add(player);
        team.DepthChart = new DepthChartService().CreateDefaultDepthChart(team.Roster);
        var service = new TransactionService();

        var success = service.CutPlayer(league, team, player.Id, out var message);

        Assert.True(success, message);
        Assert.Empty(team.Roster);
        Assert.Same(player, Assert.Single(league.FreeAgents));
        Assert.Equal(string.Empty, player.TeamId);
        Assert.DoesNotContain(player.Id, team.DepthChart.GetPlayerIdsAtPosition(player.Position));
        Assert.False(service.CutPlayer(league, team, player.Id, out _));
        Assert.Single(league.FreeAgents);
    }

    [Fact]
    public void SignFreeAgent_Allows53rdPlayerButRejects54thWithoutChangingOwnership()
    {
        var league = TestData.League();
        var team = league.Teams[0];
        team.Roster = Enumerable.Range(0, 52).Select(i => TestData.Player($"p{i}")).ToList();
        var first = TestData.Player("first", teamId: "");
        var second = TestData.Player("second", teamId: "");
        league.FreeAgents.AddRange([first, second]);
        var service = new TransactionService();

        var accepted = service.SignFreeAgent(league, team, first.Id, out _);
        var rejected = service.SignFreeAgent(league, team, second.Id, out var message);

        Assert.True(accepted);
        Assert.False(rejected);
        Assert.Equal(53, team.Roster.Count);
        Assert.Same(second, Assert.Single(league.FreeAgents));
        Assert.Equal(string.Empty, second.TeamId);
        Assert.Contains("Roster is full", message);
    }

    [Fact]
    public void InvalidIdentifiers_AreRejectedWithoutChangingCollections()
    {
        var league = TestData.League();
        var team = league.Teams[0];
        var service = new TransactionService();

        var signed = service.SignFreeAgent(league, team, "missing", out var signMessage);
        var released = service.CutPlayer(league, team, "missing", out var releaseMessage);

        Assert.False(signed);
        Assert.False(released);
        Assert.NotEmpty(signMessage);
        Assert.NotEmpty(releaseMessage);
        Assert.Empty(team.Roster);
        Assert.Empty(league.FreeAgents);
        Assert.Null(team.DepthChart);
    }

    [Fact]
    public void SignFreeAgent_RejectsDuplicateRosterIdentifier()
    {
        var league = TestData.League();
        var team = league.Teams[0];
        team.Roster.Add(TestData.Player());
        var duplicate = TestData.Player(teamId: "");
        league.FreeAgents.Add(duplicate);

        var success = new TransactionService().SignFreeAgent(league, team, duplicate.Id, out var message);

        Assert.False(success);
        Assert.Contains("already", message);
        Assert.Single(team.Roster);
        Assert.Same(duplicate, Assert.Single(league.FreeAgents));
        Assert.Equal(string.Empty, duplicate.TeamId);
    }
}
