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
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.View;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Interfaces;
using RimuruDev.Internal.Codebase.Utilities.Extensions;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Infrastructura.Factorys.ShopItems
{
    [CreateAssetMenu(menuName = "StaticData/Shop/Factory", fileName = nameof(ShopItemViewFactory), order = 0)]
    public sealed class ShopItemViewFactory : ScriptableObject
    {
        [SerializeField] private ShopItemView characterSkinItemPrefab;
        [SerializeField] private ShopItemView mazeSkinItemPrefab;

        public ShopItemView Create(ShopItem shopItem, Transform parent)
        {
            shopItem.CheckNull();

            var visitor = new ShopItemVisitor(characterSkinItemPrefab, mazeSkinItemPrefab);
            visitor.Visit(shopItem);

            var instance = Instantiate(visitor.Prefab, parent);
            instance.Initialize(shopItem);

            return instance;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate() =>
            Validate.Null(characterSkinItemPrefab, mazeSkinItemPrefab);

        private sealed class ShopItemVisitor : IShopItemVisitor
        {
            private readonly ShopItemView characterSkinItemPrefab;
            private readonly ShopItemView mazeSkinItemPrefab;

            public ShopItemVisitor(ShopItemView characterSkinItemPrefab, ShopItemView mazeSkinItemPrefab)
            {
                this.characterSkinItemPrefab = characterSkinItemPrefab
                    ? characterSkinItemPrefab
                    : throw new ArgumentNullException(nameof(characterSkinItemPrefab));

                this.mazeSkinItemPrefab = mazeSkinItemPrefab
                    ? mazeSkinItemPrefab
                    : throw new ArgumentNullException(nameof(mazeSkinItemPrefab));
            }

            public ShopItemView Prefab { get; private set; }

            public void Visit(ShopItem shopItem) =>
                this.Visit((dynamic)shopItem);

            public void Visit(CharacterSkinItem characterSkinItem) =>
                Prefab = characterSkinItemPrefab;

            public void Visit(MazeSkinItem mazeSkinItem) =>
                Prefab = mazeSkinItemPrefab;
        }
    }
}