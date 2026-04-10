using System.Collections.Generic;
using System.Linq;

namespace FootballSim.Core.Models
{
    public sealed class DepthChart
    {
        // Stores ordered player IDs by position
        public Dictionary<PlayerPosition, List<string>> PositionGroups { get; set; } = new();

        public void SetPlayersForPosition(PlayerPosition position, IEnumerable<Player> players)
        {
            PositionGroups[position] = players
                .Select(p => p.Id)
                .ToList();
        }

        public List<string> GetPlayerIdsAtPosition(PlayerPosition position)
        {
            if (PositionGroups.TryGetValue(position, out var playerIds))
            {
                return playerIds;
            }

            return new List<string>();
        }

        public List<Player> GetPlayersAtPosition(PlayerPosition position, IEnumerable<Player> roster)
        {
            var playerIds = GetPlayerIdsAtPosition(position);

            return roster
                .Where(p => playerIds.Contains(p.Id))
                .OrderBy(p => playerIds.IndexOf(p.Id))
                .ToList();
        }

        public List<Player> GetStartersAtPosition(
            PlayerPosition position,
            int starterCount,
            IEnumerable<Player> roster)
        {
            return GetPlayersAtPosition(position, roster)
                .Take(starterCount)
                .ToList();
        }
    }
}