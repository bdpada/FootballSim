namespace FootballSim.Core.Models
{
    public sealed class TeamDefinition
    {
        public string TeamId { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public TeamDefinition() { } // Required for deserialization

        public TeamDefinition(string teamId, string displayName)
        {
            TeamId = teamId;
            DisplayName = displayName;
        }

        public override string ToString() => DisplayName;
    }
}
