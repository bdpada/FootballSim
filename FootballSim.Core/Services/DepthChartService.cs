using System.Collections.Generic;
using System.Linq;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class DepthChartService
    {
        public DepthChart CreateDefaultDepthChart(IEnumerable<Player> roster)
        {
            var depthChart = new DepthChart();

            var groupedPlayers = roster
                .GroupBy(p => p.Position)
                .ToDictionary(
                    group => group.Key,
                    group => group
                        .OrderByDescending(p => p.Overall)
                        .ThenBy(p => p.LastName)
                        .ThenBy(p => p.FirstName)
                        .ToList());

            foreach (var group in groupedPlayers)
            {
                depthChart.SetPlayersForPosition(group.Key, group.Value);
            }

            return depthChart;
        }

        public List<Player> GetStarters(DepthChart depthChart, PlayerPosition position)
        {
            int starterCount = DepthChartRules.GetStarterCount(position);

            return depthChart
                .GetPlayersAtPosition(position)
                .Where(p => !p.IsInjured)
                .Take(starterCount)
                .ToList();
        }

        public bool HasInjuredPlayersAboveHealthyStarters(DepthChart depthChart, PlayerPosition position)
        {
            int starterCount = DepthChartRules.GetStarterCount(position);
            var players = depthChart.GetPlayersAtPosition(position);

            return players
                .Take(starterCount)
                .Any(p => p.IsInjured);
        }

        public bool HasEnoughHealthyPlayers(DepthChart depthChart, PlayerPosition position)
        {
            int starterCount = DepthChartRules.GetStarterCount(position);

            int healthyCount = depthChart
                .GetPlayersAtPosition(position)
                .Count(p => !p.IsInjured);

            return healthyCount >= starterCount;
        }

        public bool MovePlayerUp(DepthChart depthChart, PlayerPosition position, string playerId)
        {
            var players = depthChart.GetPlayersAtPosition(position);
            int index = players.FindIndex(p => p.Id == playerId);

            if (index <= 0)
                return false;

            (players[index - 1], players[index]) = (players[index], players[index - 1]);
            depthChart.SetPlayersForPosition(position, players);

            return true;
        }

        public bool MovePlayerDown(DepthChart depthChart, PlayerPosition position, string playerId)
        {
            var players = depthChart.GetPlayersAtPosition(position);
            int index = players.FindIndex(p => p.Id == playerId);

            if (index < 0 || index >= players.Count - 1)
                return false;

            (players[index], players[index + 1]) = (players[index + 1], players[index]);
            depthChart.SetPlayersForPosition(position, players);

            return true;
        }
    }
}