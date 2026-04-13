using System;

namespace FootballSim.Core.Models
{
    public sealed class Player
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public PlayerPosition Position { get; set; }

        // Calculated from attributes using a position-based formula.
        public int Overall { get; set; }

        public int Age { get; set; }
        public int YearsPro { get; set; }
        public string TeamId { get; set; } = string.Empty;
        public QualityTier Tier { get; set; }

        // Shared attribute pool
        // Physical
        public int Speed { get; set; }
        public int Strength { get; set; }

        // Mental / endurance
        public int Awareness { get; set; }
        public int Stamina { get; set; }
        public int Durability { get; set; }

        // Offensive skill
        public int ThrowAccuracy { get; set; }
        public int ThrowPower { get; set; }
        public int Catching { get; set; }
        public int RouteRunning { get; set; }
        public int Blocking { get; set; }

        // Defensive skill
        public int Tackling { get; set; }
        public int Coverage { get; set; }

        // Special teams
        public int Kicking { get; set; }

        public int InjuryWeeksRemaining { get; set; }

        public bool IsInjured => InjuryWeeksRemaining > 0;
        public string FullName => $"{FirstName} {LastName}";

        public Player() { } // Required for deserialization

        public Player(
            string id,
            string firstName,
            string lastName,
            PlayerPosition position,
            int age,
            int yearsPro,
            string teamId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Age = age;
            YearsPro = yearsPro;
            TeamId = teamId;
        }

        public void ApplyInjury(int weeks)
        {
            InjuryWeeksRemaining = Math.Max(InjuryWeeksRemaining, weeks);
        }

        public void AdvanceWeek()
        {
            if (InjuryWeeksRemaining > 0)
            {
                InjuryWeeksRemaining--;
            }
        }

        public override string ToString()
        {
            string injuryStatus = IsInjured ? $" [OUT {InjuryWeeksRemaining}w]" : "";
            return $"{FullName} - {Position} ({Overall}){injuryStatus}";
        }
    }
}