namespace FootballSim.Core.Models
{
    public sealed class TeamGameStats
    {
        public int Points { get; set; }
        public int PassYards { get; set; }
        public int RushYards { get; set; }
        public int Turnovers { get; set; }

        public int TotalYards => PassYards + RushYards;
    }
}