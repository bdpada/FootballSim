using System;

namespace FootballSim.Core.Models
{
    public sealed class Player
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PlayerPosition Position { get; }
        public int Overall { get; set; }
        public int Age { get; set; }
        public int YearsPro { get; set; }
        public string TeamId { get; set; }

        public bool IsInjured => InjuryWeeksRemaining > 0;
        public int InjuryWeeksRemaining { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        public Player(
            string id,
            string firstName,
            string lastName,
            PlayerPosition position,
            int overall,
            int age,
            int yearsPro,
            string teamId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Overall = overall;
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