// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using System.IO;
using Newtonsoft.Json;
using RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress;
using RimuruDev.Internal.Codebase.Infrastructura.Storages;
using RimuruDev.Internal.Codebase.Utilities.Extensions;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Infrastructura.Providers.Progress
{
    public sealed class DataLocalDataProvider : IDataProvider
    {
        private const string FileName = "UserData";
        private const string SaveFileExtension = ".json";

        private readonly IPersistenData persistenData;

        public DataLocalDataProvider(IPersistenData persistenData)
        {
            persistenData.CheckNull();
            this.persistenData = persistenData;
        }

        private string SavePath => Application.persistentDataPath;
        private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

        public void Save()
        {
            File.WriteAllText(FullPath, JsonConvert.SerializeObject(persistenData.PlayerData, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }

        public bool TryLoad()
        {
            if (IsDataAlreadyExist() == false)
                return false;

            persistenData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
            return true;
        }

        private bool IsDataAlreadyExist() =>
            File.Exists(FullPath);
    }
}