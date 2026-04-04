namespace FootballSim.Core.Models
{
    public sealed class ScheduledGame
    {
        public int WeekNumber { get; set; }

        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;
    }
}