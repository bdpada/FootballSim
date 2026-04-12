using FootballSim.Persistence.Models;
using FootballSim.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class LoadGameForm : Form
    {
        private readonly ISaveService _saveService = new JsonSaveService();

        public string? SelectedSaveName { get; private set; }

        public LoadGameForm()
        {
            InitializeComponent();
            RefreshSaveList();
        }

        private void RefreshSaveList()
        {
            lstSaves.Items.Clear();

            List<SaveFileInfo> saves = _saveService.GetAvailableSaves();

            foreach (var save in saves)
            {
                string weekText = save.CurrentWeek > 0 ? $"Week {save.CurrentWeek}" : "Week ?";
                string displayText =
                    $"{save.FileName} | {save.UserTeamName} | {weekText} | {save.LastModifiedUtc.ToLocalTime():g}";

                lstSaves.Items.Add(new SaveListItem(save.FileName, displayText));
            }

            bool hasSaves = lstSaves.Items.Count > 0;

            btnLoad.Enabled = hasSaves;
            btnDelete.Enabled = hasSaves;

            if (hasSaves)
            {
                lstSaves.SelectedIndex = 0;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSelectedSave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSaves.SelectedItem is not SaveListItem item)
            {
                MessageBox.Show("Please select a save to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete save '{item.SaveName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _saveService.Delete(item.SaveName);
                RefreshSaveList();

                if (lstSaves.Items.Count == 0)
                {
                    MessageBox.Show("There are no save files remaining.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete save:\n{ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lstSaves_DoubleClick(object sender, EventArgs e)
        {
            if (lstSaves.SelectedItem is SaveListItem)
            {
                LoadSelectedSave();
            }
        }

        private void LoadSelectedSave()
        {
            if (lstSaves.SelectedItem is not SaveListItem item)
            {
                MessageBox.Show("Please select a save to load.");
                return;
            }

            SelectedSaveName = item.SaveName;
            DialogResult = DialogResult.OK;
            Close();
        }

        private sealed class SaveListItem
        {
            public string SaveName { get; }
            public string DisplayText { get; }

            public SaveListItem(string saveName, string displayText)
            {
                SaveName = saveName;
                DisplayText = displayText;
            }

            public override string ToString() => DisplayText;
        }
    }
}