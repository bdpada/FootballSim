namespace FootballSim.Core.Models
{
    public sealed class Team
    {
        public TeamDefinition Definition { get; }

        // Additional properties to expand later
        public int OffenseRating { get; set; } = 70;
        public int DefenseRating { get; set; } = 70;

        public Team(TeamDefinition definition, int offenseRating = 70, int defenseRating = 70)
        {
            Definition = definition;
            OffenseRating = offenseRating;
            DefenseRating = defenseRating;
        }

        //Convenience passthroughs so UI and sim an still do team.Id / team.Name
        public string Id => Definition.TeamId;
        public string Name => Definition.DisplayName;
        public override string ToString() => $"{Name} ({Id})";
    }
}
