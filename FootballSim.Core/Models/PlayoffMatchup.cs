namespace FootballSim.Core.Models
{
    public sealed class PlayoffMatchup
    {
        public PlayoffRound Round { get; set; }

        public int MatchupNumber { get; set; }

        public string HomeTeamId { get; set; } = string.Empty;
        public string AwayTeamId { get; set; } = string.Empty;

        public GameResult? Result { get; set; }

        public string WinnerTeamId { get; set; } = string.Empty;

        public bool IsCompleted => !string.IsNullOrWhiteSpace(WinnerTeamId);
    }
}