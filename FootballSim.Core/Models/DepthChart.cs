using System.Collections.Generic;
using System.Linq;

namespace FootballSim.Core.Models
{
    public sealed class DepthChart
    {
        private readonly Dictionary<PlayerPosition, List<Player>> _positionGroups = new();

        public IReadOnlyDictionary<PlayerPosition, List<Player>> PositionGroups => _positionGroups;

        public void SetPlayersForPosition(PlayerPosition position, IEnumerable<Player> players)
        {
            _positionGroups[position] = players.ToList();
        }

        public List<Player> GetPlayersAtPosition(PlayerPosition position)
        {
            if (_positionGroups.TryGetValue(position, out var players))
            {
                return players;
            }

            return new List<Player>();
        }

        public List<Player> GetStartersAtPosition(PlayerPosition position, int starterCount)
        {
            return GetPlayersAtPosition(position)
                .Take(starterCount)
                .ToList();
        }
    }
}