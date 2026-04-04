using FootballSim.Core.Models;
using System;

namespace FootballSim.Core.Services
{
    public sealed class RandomPlayerGenerator
    {
        private readonly Random _random = new();

        private static readonly string[] FirstNames =
        {
            "John", "Mike", "Chris", "James", "Robert", "David", "Daniel", "Marcus"
        };

        private static readonly string[] LastNames =
        {
            "Smith", "Johnson", "Brown", "Williams", "Jones", "Miller", "Davis", "Wilson"
        };

        public Player CreatePlayer(PlayerPosition position, string teamId)
        {
            var firstName = FirstNames[_random.Next(FirstNames.Length)];
            var lastName = LastNames[_random.Next(LastNames.Length)];

            int overall = _random.Next(60, 91); // MVP range
            int age = _random.Next(21, 33);
            int yearsPro = Math.Max(0, age - 21);

            return new Player(
                Guid.NewGuid().ToString(),
                firstName,
                lastName,
                position,
                overall,
                age,
                yearsPro,
                teamId
            );
        }
    }
}