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
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins
{
    [CreateAssetMenu(fileName = nameof(ShopContent), menuName = "StaticData/Shop/ShopContent", order = 3)]
    public class ShopContent : ScriptableObject
    {
        [field: SerializeField] public List<CharacterSkinItem> characterSkinItem;
        [field: SerializeField] public List<MazeSkinItem> mzeSkinItem;

        public IEnumerable<CharacterSkinItem> CharacterSkinItem => characterSkinItem;
        public IEnumerable<MazeSkinItem> MazeSkinItem => mzeSkinItem;

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate()
        {
            var characterSkinsDuplicates = characterSkinItem.GroupBy(item => item.SkinType)
                .Where(array => array.Count() > 1);

            if (characterSkinsDuplicates.Any()) // characterSkinsDuplicates.Count() > 0
                throw new InvalidOperationException(nameof(characterSkinItem));

            var mazeSkinDuplicates = mzeSkinItem.GroupBy(item => item.SkinType)
                .Where(array => array.Count() > 1);

            if (mazeSkinDuplicates.Any()) // mazeSkinDuplicates.Count() > 0
                throw new InvalidOperationException(nameof(mzeSkinItem));
        }
    }
}