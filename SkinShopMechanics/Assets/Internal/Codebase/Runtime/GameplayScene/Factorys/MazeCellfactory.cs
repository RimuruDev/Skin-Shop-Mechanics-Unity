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

using System;
using RimuruDev.Internal.Codebase.Runtime.GameplayScene.Maze;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.GameplayScene.Factorys
{
    [CreateAssetMenu(menuName = "StaticData/GameplayScene/MazeCellfactory", fileName = nameof(MazeCellfactory), order = 1)]
    public sealed class MazeCellfactory : ScriptableObject
    {
        [SerializeField] private MazeCell greenTheme;
        [SerializeField] private MazeCell egyptTheme;
        [SerializeField] private MazeCell cristallTheme;
        [SerializeField] private MazeCell jungleTheme;
        [SerializeField] private MazeCell chinaTheme;
        [SerializeField] private MazeCell beachTheme;
        [SerializeField] private MazeCell treasuryTheme;

        public MazeCell Create(MazeSkins skinType, Vector3 spawnPosition)
        {
            var instance = Instantiate(GetPrefab(skinType), spawnPosition, Quaternion.identity, null);

            instance.Initialize();

            return instance;
        }

        private MazeCell GetPrefab(MazeSkins skinType)
        {
            return skinType switch
            {
                MazeSkins.Green => greenTheme,
                MazeSkins.Egypt => egyptTheme,
                MazeSkins.Cristall => cristallTheme,
                MazeSkins.Jungle => jungleTheme,
                MazeSkins.China => chinaTheme,
                MazeSkins.Beach => beachTheme,
                MazeSkins.Treasury => treasuryTheme,
                _ => throw new ArgumentException(nameof(skinType))
            };
        }
    }
}