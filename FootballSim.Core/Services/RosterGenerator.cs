using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public sealed class RosterGenerator
    {
        private readonly RandomPlayerGenerator _playerGenerator = new();

        public void GenerateRoster(Team team)
        {
            AddPlayers(team, PlayerPosition.QB, 2);
            AddPlayers(team, PlayerPosition.RB, 2);
            AddPlayers(team, PlayerPosition.WR, 4);
            AddPlayers(team, PlayerPosition.TE, 2);

            AddPlayers(team, PlayerPosition.C, 2);
            AddPlayers(team, PlayerPosition.G, 3);
            AddPlayers(team, PlayerPosition.T, 3);

            AddPlayers(team, PlayerPosition.DE, 3);
            AddPlayers(team, PlayerPosition.DT, 3);
            AddPlayers(team, PlayerPosition.ILB, 3);
            AddPlayers(team, PlayerPosition.OLB, 3);
            AddPlayers(team, PlayerPosition.CB, 4);
            AddPlayers(team, PlayerPosition.S, 3);

            AddPlayers(team, PlayerPosition.K, 1);
        }

        private void AddPlayers(Team team, PlayerPosition position, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var player = _playerGenerator.CreatePlayer(position, team.Id);
                team.Roster.Add(player);
            }
        }
    }
}