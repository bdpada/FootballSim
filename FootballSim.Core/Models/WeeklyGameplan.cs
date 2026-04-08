namespace FootballSim.Core.Models
{
    public sealed class WeeklyGameplan
    {
        public OffenseFocus OffenseFocus { get; set; } = OffenseFocus.Balanced;
        public DefenseFocus DefenseFocus { get; set; } = DefenseFocus.Balanced;

        public override string ToString()
        {
            return $"Offense: {OffenseFocus}, Defense: {DefenseFocus}";
        }
    }
}