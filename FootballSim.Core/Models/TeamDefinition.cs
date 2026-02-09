using System;
using System.Collections.Generic;
using System.Text;

namespace FootballSim.Core.Models
{
    public sealed class TeamDefinition
    {
        public string TeamId { get; }
        public string DisplayName { get; }

        public TeamDefinition(string teamId, string displayName)
        {
            TeamId = teamId;
            DisplayName = displayName;
        }

        public override string ToString() => DisplayName;
    }
}
