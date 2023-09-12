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
using UnityEngine;
using RimuruDev.Internal.Codebase.Runtime.GameplayScene.Hero;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;

namespace RimuruDev.Internal.Codebase.Runtime.GameplayScene.Factorys
{
    [CreateAssetMenu(menuName = "StaticData/GameplayScene/CharacterFactory", fileName = nameof(CharacterFactory),
        order = 0)]
    public sealed class CharacterFactory : ScriptableObject
    {
        [SerializeField] private Character anubis;
        [SerializeField] private Character bat;
        [SerializeField] private Character bear;
        [SerializeField] private Character bearArmor;
        [SerializeField] private Character cat;
        [SerializeField] private Character deer;
        [SerializeField] private Character dog;
        [SerializeField] private Character dogBeach;
        [SerializeField] private Character dragon;
        [SerializeField] private Character hare;
        [SerializeField] private Character monkey;
        [SerializeField] private Character mouse;
        [SerializeField] private Character panda;
        [SerializeField] private Character parrot;
        [SerializeField] private Character penguin;
        [SerializeField] private Character pharaon;
        [SerializeField] private Character ra;
        [SerializeField] private Character redPanda;
        [SerializeField] private Character duck;

        public Character Create(CharacterSkins skinType, Vector3 spawnPosition)
        {
            var instance = Instantiate(GetPrefab(skinType), spawnPosition, Quaternion.identity, null);

            instance.Initialize();

            return instance;
        }

        private Character GetPrefab(CharacterSkins skinType)
        {
            return skinType switch
            {
                CharacterSkins.Anubis => anubis,
                CharacterSkins.Bat => bat,
                CharacterSkins.Bear => bear,
                CharacterSkins.BearArmor => bearArmor,
                CharacterSkins.Cat => cat,
                CharacterSkins.Deer => deer,
                CharacterSkins.Dog => dog,
                CharacterSkins.DogBeach => dogBeach,
                CharacterSkins.Dragon => dragon,
                CharacterSkins.Hare => hare,
                CharacterSkins.Monkey => monkey,
                CharacterSkins.Mouse => mouse,
                CharacterSkins.Panda => panda,
                CharacterSkins.Parrot => parrot,
                CharacterSkins.Penguin => penguin,
                CharacterSkins.Pharaon => pharaon,
                CharacterSkins.Ra => ra,
                CharacterSkins.RedPanda => redPanda,
                CharacterSkins.Duck => duck,
                _ => throw new ArgumentException(nameof(skinType))
            };
        }
    }
}