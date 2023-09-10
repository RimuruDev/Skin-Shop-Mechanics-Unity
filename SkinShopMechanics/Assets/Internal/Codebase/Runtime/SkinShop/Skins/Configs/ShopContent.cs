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
using System.Linq;
using NaughtyAttributes;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs
{
    [CreateAssetMenu(fileName = nameof(ShopContent), menuName = "StaticData/Shop/ShopContent", order = 3)]
    public class ShopContent : ScriptableObject
    {
        [field: SerializeField, Expandable] public List<CharacterSkinItem> characterSkinItem;
        [field: SerializeField, Expandable] public List<MazeSkinItem> mzeSkinItem;

        public IEnumerable<CharacterSkinItem> CharacterSkinItem => characterSkinItem;
        public IEnumerable<MazeSkinItem> MazeSkinItem => mzeSkinItem;

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate()
        {
            ValidateDuplicates(characterSkinItem, item => item.SkinType);
            ValidateDuplicates(mzeSkinItem, item => item.SkinType);
        }

        private static void ValidateDuplicates<TCollection, TKey>(IEnumerable<TCollection> enumerable, Func<TCollection, TKey> keySelector)
            where TCollection : ShopItem
        {
            var duplicates = enumerable.GroupBy(keySelector)
                .Where(group => group.Count() > 1);

            if (duplicates.Any())
                throw new InvalidOperationException(nameof(enumerable));
        }
    }
}