using System;

namespace FootballSim.Persistence.Models
{
    public sealed class SaveFileInfo
    {
        public string FileName { get; set; } = string.Empty;
        public string FullPath { get; set; } = string.Empty;
        public DateTime LastModifiedUtc { get; set; }

        public string UserTeamName { get; set; } = string.Empty;
        public int CurrentWeek { get; set; }
    }
}