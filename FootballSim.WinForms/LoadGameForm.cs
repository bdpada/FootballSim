using FootballSim.Persistence.Models;
using FootballSim.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
                lstSaves.Items.Add(new SaveListItem(
                    save.FileName,
                    $"{save.FileName}  |  {save.LastModifiedUtc.ToLocalTime():g}"));
            }

            btnLoad.Enabled = lstSaves.Items.Count > 0;
            btnDelete.Enabled = lstSaves.Items.Count > 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
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