using FootballSim.Core.Models;

namespace FootballSim.Core.Services
{
    public interface IGameSimulator
    {
        GameResult SimulateGame(ScheduledGame scheduledGame);
    }
}