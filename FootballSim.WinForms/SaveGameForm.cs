using FootballSim.Persistence.Models;
using FootballSim.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootballSim.WinForms
{
    public partial class SaveGameForm : Form
    {
        private readonly ISaveService _saveService = new JsonSaveService();

        public string? SelectedSaveName { get; private set; }

        public SaveGameForm()
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

            if (lstSaves.Items.Count > 0)
            {
                lstSaves.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveName = txtSaveName.Text.Trim();

            if (string.IsNullOrWhiteSpace(saveName))
            {
                if (lstSaves.SelectedItem is SaveListItem selectedItem)
                {
                    saveName = selectedItem.SaveName;
                }
            }

            if (string.IsNullOrWhiteSpace(saveName))
            {
                MessageBox.Show("Enter a save name or select an existing save.");
                return;
            }

            SelectedSaveName = saveName;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lstSaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSaves.SelectedItem is SaveListItem item)
            {
                txtSaveName.Text = item.SaveName;
            }
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