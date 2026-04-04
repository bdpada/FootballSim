namespace FootballSim.Core.Models
{
    public sealed class TeamRecord
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }

        public override string ToString()
        {
            return $"{Wins}-{Losses}-{Ties}";
        }
    }
}