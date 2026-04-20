using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class RosterGenerator
    {
        private readonly RandomPlayerGenerator _playerGenerator = new();

        public void GenerateRoster(Team team)
        {
            AddPlayers(team, PlayerPosition.QB, 3);
            AddPlayers(team, PlayerPosition.RB, 4);
            AddPlayers(team, PlayerPosition.WR, 6);
            AddPlayers(team, PlayerPosition.TE, 3);

            AddPlayers(team, PlayerPosition.C, 2);
            AddPlayers(team, PlayerPosition.G, 4);
            AddPlayers(team, PlayerPosition.T, 4);

            AddPlayers(team, PlayerPosition.DE, 4);
            AddPlayers(team, PlayerPosition.DT, 4);
            AddPlayers(team, PlayerPosition.ILB, 4);
            AddPlayers(team, PlayerPosition.OLB, 4);
            AddPlayers(team, PlayerPosition.CB, 6);
            AddPlayers(team, PlayerPosition.S, 4);

            AddPlayers(team, PlayerPosition.K, 1);
        }

        public Player GenerateFreeAgentPlayer()
        {
            var position = GetRandomFreeAgentPosition();
            return _playerGenerator.CreateFreeAgentPlayer(position);
        }

        private void AddPlayers(Team team, PlayerPosition position, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var player = _playerGenerator.CreatePlayer(position, team.Id);
                team.Roster.Add(player);
            }
        }

        private PlayerPosition GetRandomFreeAgentPosition()
        {
            PlayerPosition[] positions =
            {
                PlayerPosition.QB,
                PlayerPosition.RB,
                PlayerPosition.WR,
                PlayerPosition.TE,
                PlayerPosition.C,
                PlayerPosition.G,
                PlayerPosition.T,
                PlayerPosition.DE,
                PlayerPosition.DT,
                PlayerPosition.ILB,
                PlayerPosition.OLB,
                PlayerPosition.CB,
                PlayerPosition.S,
                PlayerPosition.K
            };

            return positions[Random.Shared.Next(positions.Length)];
        }
    }
}
