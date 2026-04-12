using System.Collections.Generic;
using FootballSim.Core.Models;
using FootballSim.Persistence.Models;

namespace FootballSim.Persistence.Services
{
    public interface ISaveService
    {
        void Save(string saveName, FranchiseState franchise);
        FranchiseState Load(string saveName);
        List<SaveFileInfo> GetAvailableSaves();
        bool SaveExists(string saveName);
        void Delete(string saveName);
    }
}