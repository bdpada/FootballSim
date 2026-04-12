using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FootballSim.Core.Models;
using FootballSim.Persistence.Models;

namespace FootballSim.Persistence.Services
{
    public sealed class JsonSaveService : ISaveService
    {
        private readonly string _saveFolderPath;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonSaveService(string? saveFolderPath = null)
        {
            _saveFolderPath = saveFolderPath ?? GetDefaultSaveFolderPath();

            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            Directory.CreateDirectory(_saveFolderPath);
        }

        public void Save(string saveName, FranchiseState franchise)
        {
            if (string.IsNullOrWhiteSpace(saveName))
            {
                throw new ArgumentException("Save name cannot be empty.", nameof(saveName));
            }

            if (franchise == null)
            {
                throw new ArgumentNullException(nameof(franchise));
            }

            string fullPath = GetSaveFilePath(saveName);
            string json = JsonSerializer.Serialize(franchise, _jsonOptions);

            File.WriteAllText(fullPath, json);
        }

        public void Delete(string saveName)
        {
            if (string.IsNullOrWhiteSpace(saveName))
            {
                throw new ArgumentException("Save name cannot be empty.", nameof(saveName));
            }

            string fullPath = GetSaveFilePath(saveName);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("Save file was not found.", fullPath);
            }

            File.Delete(fullPath);
        }

        public FranchiseState Load(string saveName)
        {
            if (string.IsNullOrWhiteSpace(saveName))
            {
                throw new ArgumentException("Save name cannot be empty.", nameof(saveName));
            }

            string fullPath = GetSaveFilePath(saveName);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("Save file was not found.", fullPath);
            }

            string json = File.ReadAllText(fullPath);

            FranchiseState? franchise = JsonSerializer.Deserialize<FranchiseState>(json, _jsonOptions);

            if (franchise == null)
            {
                throw new InvalidOperationException("Failed to deserialize the save file.");
            }

            return franchise;
        }

        public List<SaveFileInfo> GetAvailableSaves()
        {
            Directory.CreateDirectory(_saveFolderPath);

            return Directory
                .GetFiles(_saveFolderPath, "*.json", SearchOption.TopDirectoryOnly)
                .Select(path => BuildSaveFileInfo(path))
                .OrderByDescending(save => save.LastModifiedUtc)
                .ToList();
        }

        public bool SaveExists(string saveName)
        {
            string fullPath = GetSaveFilePath(saveName);
            return File.Exists(fullPath);
        }

        private string GetSaveFilePath(string saveName)
        {
            string safeFileName = MakeSafeFileName(saveName);
            return Path.Combine(_saveFolderPath, $"{safeFileName}.json");
        }

        private static string MakeSafeFileName(string saveName)
        {
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                saveName = saveName.Replace(invalidChar, '_');
            }

            return saveName.Trim();
        }

        private static string GetDefaultSaveFolderPath()
        {
            return Path.Combine(AppContext.BaseDirectory, "Saves");
        }

        private SaveFileInfo BuildSaveFileInfo(string path)
        {
            var file = new FileInfo(path);

            var info = new SaveFileInfo
            {
                FileName = Path.GetFileNameWithoutExtension(file.Name),
                FullPath = file.FullName,
                LastModifiedUtc = file.LastWriteTimeUtc,
                UserTeamName = "Unknown Team",
                CurrentWeek = 0
            };

            try
            {
                string json = File.ReadAllText(path);
                FranchiseState? franchise = JsonSerializer.Deserialize<FranchiseState>(json, _jsonOptions);

                if (franchise != null)
                {
                    info.CurrentWeek = franchise.CurrentWeek;
                    info.UserTeamName = franchise.UserTeam?.Name ?? franchise.UserTeamId;
                }
            }
            catch
            {
                info.UserTeamName = "Unreadable Save";
                info.CurrentWeek = 0;
            }

            return info;
        }
    }
}