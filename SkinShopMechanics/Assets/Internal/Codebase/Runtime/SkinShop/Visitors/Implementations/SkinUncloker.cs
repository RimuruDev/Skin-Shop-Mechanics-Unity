﻿// **************************************************************** //
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
using RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Interfaces;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Implementations
{
    public sealed class SkinUncloker : IShopItemVisitor
    {
        private readonly IPersistenData persistenData;

        public SkinUncloker(IPersistenData persistenData) =>
            this.persistenData = persistenData ?? throw new ArgumentNullException(nameof(persistenData));

        public void Visit(ShopItem shopItem) =>
            this.Visit((dynamic)shopItem);

        public void Visit(CharacterSkinItem characterSkinItem) =>
            persistenData.PlayerData.OpenCharacterSkin(characterSkinItem.SkinType);

        public void Visit(MazeSkinItem mazeSkinItem) =>
            persistenData.PlayerData.OpenMazeSkin(mazeSkinItem.SkinType);
    }
}