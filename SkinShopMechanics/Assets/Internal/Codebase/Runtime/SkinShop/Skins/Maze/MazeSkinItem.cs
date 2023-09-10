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

using UnityEngine;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Maze
{
    [CreateAssetMenu(fileName = nameof(MazeSkinItem), menuName = "StaticData/Shop/" + nameof(MazeSkinItem), order = 0)]
    public class MazeSkinItem : ShopItem
    {
        [field: SerializeField] public MazeSkins SkinType { get; private set; }
    }
}