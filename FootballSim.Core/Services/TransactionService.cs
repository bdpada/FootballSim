using System.Linq;
using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class TransactionService
    {
        public const int MaxRosterSize = 53;

        private readonly DepthChartService _depthChartService = new();
        private readonly TeamRatingCalculator _teamRatingCalculator = new();

        public bool SignFreeAgent(League league, Team team, string playerId, out string message)
        {
            if (team.Roster.Count >= MaxRosterSize)
            {
                message = $"Roster is full ({team.Roster.Count}/{MaxRosterSize}). Cut a player before signing.";
                return false;
            }

            var player = league.FreeAgents.FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                message = "Selected free agent was not found.";
                return false;
            }

            if (team.Roster.Any(p => p.Id == playerId))
            {
                message = "Player is already on your roster.";
                return false;
            }

            league.FreeAgents.Remove(player);

            player.TeamId = team.Id;
            team.Roster.Add(player);

            if (team.DepthChart == null)
            {
                team.DepthChart = _depthChartService.CreateDefaultDepthChart(team.Roster);
            }
            else
            {
                AddPlayerToDepthChart(team, player);
                _depthChartService.AutoFixPosition(team.DepthChart, team.Roster, player.Position);
            }

            _teamRatingCalculator.ApplyCalculatedRatings(team);

            message = $"{player.FullName} signed successfully. Roster: {team.Roster.Count}/{MaxRosterSize}";
            return true;
        }

        private void AddPlayerToDepthChart(Team team, Player player)
        {
            if (team.DepthChart == null)
                return;

            var playersAtPosition = team.DepthChart.GetPlayersAtPosition(player.Position, team.Roster);

            if (playersAtPosition.Any(p => p.Id == player.Id))
                return;

            playersAtPosition.Add(player);
            team.DepthChart.SetPlayersForPosition(player.Position, playersAtPosition);
        }

        private void RemovePlayerFromDepthChart(Team team, Player player)
        {
            if (team.DepthChart == null)
                return;

            var playersAtPosition = team.DepthChart.GetPlayersAtPosition(player.Position, team.Roster);

            var updatedList = playersAtPosition
                .Where(p => p.Id != player.Id)
                .ToList();

            team.DepthChart.SetPlayersForPosition(player.Position, updatedList);
        }

        public bool CutPlayer(League league, Team team, string playerId, out string message)
        {
            var player = team.Roster.FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                message = "Player not found on roster.";
                return false;
            }

            team.Roster.Remove(player);

            RemovePlayerFromDepthChart(team, player);

            player.TeamId = string.Empty;
            league.FreeAgents.Add(player);

            if (team.DepthChart != null)
            {
                _depthChartService.AutoFixPosition(team.DepthChart, team.Roster, player.Position);
            }

            _teamRatingCalculator.ApplyCalculatedRatings(team);

            message = $"{player.FullName} has been released. Roster: {team.Roster.Count}/{MaxRosterSize}";
            return true;
        }
    }
}