namespace FootballSim.Core.Models
{
    public sealed class FranchiseState
    {
        public League League { get; }
        public string UserTeamId { get; }
        public int CurrentWeek { get; set; } = 1;
        
        public FranchiseState(League league, string userTeamId)
        {
            League = league;
            UserTeamId = userTeamId;
        }

        public Team? UserTeam => League.GetTeamById(UserTeamId);
    }
}
