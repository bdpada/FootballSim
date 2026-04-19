using FootballSim.Core.Models;

namespace FootballSim.WinForms.Helpers
{
    public static class PlayerFormHelper
    {
        public static void ShowPlayerDetails(Player player)
        {
            if (player == null)
                return;

            var form = new PlayerDetailsForm(player);
            form.Show();
        }
    }
}