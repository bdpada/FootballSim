using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public interface IGameSimulator
    {
        GameResult SimulateGame(League league, ScheduledGame scheduledGame);
    }
}