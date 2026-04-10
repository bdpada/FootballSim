using System.Collections.Generic;

namespace FootballSim.Core.Models
{
    public sealed class Team
    {
        public TeamDefinition Definition { get; set; } = null!;

        // Additional properties to expand later
        public int OffenseRating { get; set; } = 70;
        public int DefenseRating { get; set; } = 70;

        public TeamRecord Record { get; set; } = new();
        public List<Player> Roster { get; set; } = new();
        public DepthChart? DepthChart { get; set; }

        public Team() { } // Required for deserialization

        public Team(TeamDefinition definition, int offenseRating = 70, int defenseRating = 70)
        {
            Definition = definition;
            OffenseRating = offenseRating;
            DefenseRating = defenseRating;
        }

        // Convenience passthroughs so UI and sim can still do team.Id / team.Name
        public string Id => Definition.TeamId;
        public string Name => Definition.DisplayName;

        public override string ToString() => $"{Name} ({Id})";
    }
}