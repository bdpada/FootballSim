namespace FootballSim.Core.Models
{
    public sealed class FranchiseState
    {
        public League League { get; set; } = null!;
        public string UserTeamId { get; set; } = string.Empty;
        public int CurrentWeek { get; set; } = 1;

        //User's weekly strategy settings. No need to alter each team yet
        public WeeklyGameplan WeeklyGameplan { get; set; } = new();

        public FranchiseState() { } // Parameterless constructor for deserialization

        public FranchiseState(League league, string userTeamId)
        {
            League = league;
            UserTeamId = userTeamId;
        }

        public Team? UserTeam => League.GetTeamById(UserTeamId);
    }
}
