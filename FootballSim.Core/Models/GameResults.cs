namespace FootballSim.Core.Models
{
    public sealed class GameResult
    {
        public int WeekNumber { get; set; }

        public string HomeTeamId { get; set; } = string.Empty;
        public string AwayTeamId { get; set; } = string.Empty;

        public TeamGameStats HomeStats { get; set; } = new();
        public TeamGameStats AwayStats { get; set; } = new();

        public string WinnerTeamId
        {
            get
            {
                return HomeStats.Points >= AwayStats.Points
                    ? HomeTeamId
                    : AwayTeamId;
            }
        }
    }
}