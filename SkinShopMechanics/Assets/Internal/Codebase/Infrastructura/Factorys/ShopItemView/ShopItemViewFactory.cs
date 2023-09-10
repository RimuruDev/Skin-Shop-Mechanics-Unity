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
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using RimuruDev.Internal.Codebase.Utilities.Extensions;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Infrastructura.Factorys.ShopItemView
{
    [CreateAssetMenu(menuName = "StaticData/Shop/Factory", fileName = nameof(ShopItemViewFactory), order = 0)]
    public sealed class ShopItemViewFactory : ScriptableObject
    {
        [SerializeField] private Runtime.SkinShop.Skins.View.ShopItemView characterSkinItemPrefab;
        [SerializeField] private Runtime.SkinShop.Skins.View.ShopItemView mazeSkinItemPrefab;

        public Runtime.SkinShop.Skins.View.ShopItemView Create(ShopItem shopItem, Transform parent)
        {
            shopItem.CheckNull();

            var instance = shopItem switch
            {
                CharacterSkinItem characterSkinItem => Instantiate(characterSkinItemPrefab, parent),
                MazeSkinItem characterSkinItem => Instantiate(mazeSkinItemPrefab, parent),
                _ => throw new ArgumentNullException(nameof(shopItem))
            };

            instance.Initialize(shopItem);

            return instance;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate() =>
            Validate.Null(characterSkinItemPrefab, mazeSkinItemPrefab);
    }
}