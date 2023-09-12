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

using RimuruDev.Internal.Codebase.Infrastructura.Storages;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress
{
    public sealed class PersistenData : IPersistenData
    {
        private PlayerData playerData;

        public PlayerData PlayerData
        {
            get => playerData;
            set
            {
                if (value == null)
                {
                    Debug.LogWarning("You are trying to pass null by destroying the progress data...");
                    return;
                }

                playerData = value;
            }
        }
    }
}