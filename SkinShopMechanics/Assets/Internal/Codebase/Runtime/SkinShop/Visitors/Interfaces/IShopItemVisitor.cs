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

using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Interfaces
{
    public interface IShopItemVisitor
    {
        public void Visit(ShopItem shopItem);
        public void Visit(CharacterSkinItem characterSkinItem);
        public void Visit(MazeSkinItem mazeSkinItem);
    }
}