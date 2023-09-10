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
using System.Collections.Generic;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.Data
{
    [Serializable]
    public sealed class PlayerData
    {
        private CharacterSkins selectCharacterSkins;
        private MazeSkins selectMazeSkins;

        private IList<CharacterSkins> openCharacterSkins;
        private IList<MazeSkins> openMazeSkins;

        private int currency;

        public PlayerData()
        {
            currency = 50000;

            selectCharacterSkins = CharacterSkins.Bat;
            selectMazeSkins = MazeSkins.China;

            openCharacterSkins = new List<CharacterSkins> { selectCharacterSkins };
            openMazeSkins = new List<MazeSkins> { selectMazeSkins };
        }

        public int Currency
        {
            get => currency;
            set
            {
                try
                {
                    if (value is < 0 or > int.MaxValue)
                        throw new ArgumentOutOfRangeException(nameof(value));

                    currency = value;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    currency = Mathf.Clamp(value, 0, int.MaxValue);
                    Debug.LogError($"ArgumentOutOfRangeException: Current currency: {currency} Value: {value}");
                }
            }
        }

        public CharacterSkins SelectCharacterSkins
        {
            get => selectCharacterSkins;
            set
            {
                try
                {
                    if (openCharacterSkins.Contains(value) == false)
                        throw new ArgumentException(nameof(value));

                    selectCharacterSkins = value;
                }
                catch (ArgumentException ex)
                {
                    Debug.LogError($"ArgumentException: Current character: {currency} Value: {value}");
                }
            }
        }

        public MazeSkins SelectMazeSkins
        {
            get => selectMazeSkins;
            set
            {
                try
                {
                    if (openMazeSkins.Contains(value) == false)
                        throw new ArgumentException(nameof(value));

                    selectMazeSkins = value;
                }
                catch (ArgumentException ex)
                {
                    Debug.LogError($"ArgumentException: Current maze: {currency} Value: {value} ");
                }
            }
        }

        public IEnumerable<CharacterSkins> OpenCharacterSkins =>
            openCharacterSkins;

        public IEnumerable<MazeSkins> OpenMazeSkins =>
            openMazeSkins;

        public void OpenCharacterSkin(CharacterSkins skins)
        {
            try
            {
                if (openCharacterSkins.Contains(skins))
                    throw new ArgumentException(nameof(skins));

                openCharacterSkins.Add(skins);
            }
            catch (ArgumentException ex)
            {
                Debug.LogError("The skin has already been purchased, but you are trying to buy it again.");
            }
        }

        public void OpenMazeSkin(MazeSkins maze)
        {
            try
            {
                if (openMazeSkins.Contains(maze))
                    throw new ArgumentException(nameof(maze));

                openMazeSkins.Add(maze);
            }
            catch (ArgumentException ex)
            {
                Debug.LogError("The maze has already been purchased, but you are trying to buy it again.");
            }
        }
    }
}