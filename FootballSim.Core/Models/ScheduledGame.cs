namespace FootballSim.Core.Models
{
    public sealed class ScheduledGame
    {
        public int WeekNumber { get; set; }

        public string HomeTeamId { get; set; } = string.Empty;
        public string AwayTeamId { get; set; } = string.Empty;
    }
}