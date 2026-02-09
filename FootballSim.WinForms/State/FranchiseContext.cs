using FootballSim.Core.Models;

namespace FootballSim.WinForms.State
{
    /// <summary>
    /// Holds the currently loaded franchise for the UI layer.
    /// WinForms reads from here instead of passing FranchiseState around.
    /// </summary>
    public static class FranchiseContext
    {
        public static FranchiseState? Current { get; private set; }

        public static bool HasFranchise => Current != null;

        public static void Set(FranchiseState franchise)
        {
            Current = franchise;
        }

        public static void Clear()
        {
            Current = null;
        }
    }
}
