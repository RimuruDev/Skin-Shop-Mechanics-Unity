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

using UnityEngine;
using NaughtyAttributes;
using RimuruDev.Internal.Codebase.Infrastructura.Providers.Progress;
using RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress;
using RimuruDev.Internal.Codebase.Infrastructura.Storages;
using RimuruDev.Internal.Codebase.Runtime.GameplayScene.Factorys;

namespace RimuruDev.Internal.Codebase.Runtime.GameplayScene.Boot
{
    [DisallowMultipleComponent]
    public sealed class GameplayBootstrupper : MonoBehaviour
    {
        [SerializeField] private Transform characterSpawnPoint;
        [SerializeField] private Transform mazeSpawnPoint;

        [SerializeField, Expandable, Space] private CharacterFactory characterFactory;
        [SerializeField, Expandable] private MazeCellfactory mazeCellfactory;

        private IDataProvider dataProvider;
        private IPersistenData persistentPlayerData;

        private void Awake()
        {
            InitializeData();

            DoTestSpawn();
        }

        private void DoTestSpawn()
        {
            var character = characterFactory.Create(persistentPlayerData.PlayerData.SelectCharacterSkins,
                characterSpawnPoint.position);

            var mazeCell = mazeCellfactory.Create(persistentPlayerData.PlayerData.SelectMazeSkins,
                mazeSpawnPoint.position);

            {
                var characterSkins = persistentPlayerData.PlayerData.SelectCharacterSkins;
                var mazeSkins = persistentPlayerData.PlayerData.SelectMazeSkins;

                Debug.Log($"Заспавнили персонажа: {characterSkins} и клетки лабиринта: {mazeSkins}");
            }
        }

        private void InitializeData()
        {
            persistentPlayerData = new PersistenData();
            dataProvider = new DataLocalDataProvider(persistentPlayerData);

            LoadDataOrInit();
        }

        private void LoadDataOrInit()
        {
            if (dataProvider.TryLoad() == false)
                persistentPlayerData.PlayerData = new PlayerData();
        }
    }
}