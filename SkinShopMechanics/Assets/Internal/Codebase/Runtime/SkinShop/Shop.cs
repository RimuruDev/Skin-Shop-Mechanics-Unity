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
using NaughtyAttributes;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Panels;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop
{
    [DisallowMultipleComponent]
    public sealed class Shop : MonoBehaviour
    {
        [SerializeField, Expandable] private ShopContent contentItems;

        [SerializeField] private ShopCategoryButton characterSkinButtons;
        [SerializeField] private ShopCategoryButton mazeSkinButtons;

        [SerializeField] private ShopPanel shopPanel;
    }
}