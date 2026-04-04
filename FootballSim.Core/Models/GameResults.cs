namespace FootballSim.Core.Models
{
    public sealed class GameResult
    {
        public int WeekNumber { get; set; }

        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;

        public TeamGameStats HomeStats { get; set; } = new();
        public TeamGameStats AwayStats { get; set; } = new();

        public Team Winner
        {
            get
            {
                return HomeStats.Points >= AwayStats.Points ? HomeTeam : AwayTeam;
            }
        }
    }
}