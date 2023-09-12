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
using System.Linq;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Interfaces;
using RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Implementations
{
    public sealed class OpenSkinsChecker : IShopItemVisitor
    {
        private readonly IPersistenData persistenData;

        public bool IsOpened { get; private set; }

        public OpenSkinsChecker(IPersistenData persistenData) =>
            this.persistenData = persistenData ?? throw new ArgumentNullException(nameof(persistenData));

        public void Visit(ShopItem shopItem) =>
            this.Visit((dynamic)shopItem);

        public void Visit(CharacterSkinItem characterSkinItem) =>
            IsOpened = persistenData.PlayerData.OpenCharacterSkins.Contains(characterSkinItem.SkinType);

        public void Visit(MazeSkinItem mazeSkinItem) =>
            IsOpened = persistenData.PlayerData.OpenMazeSkins.Contains(mazeSkinItem.SkinType);
    }
}