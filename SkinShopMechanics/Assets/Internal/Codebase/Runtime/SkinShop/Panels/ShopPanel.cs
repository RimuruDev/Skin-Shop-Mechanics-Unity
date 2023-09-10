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

using System.Collections.Generic;
using System.Linq;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.View;
using Unity.VisualScripting;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Panels
{
    [DisallowMultipleComponent]
    public class ShopPanel : MonoBehaviour
    {
        private readonly IList<ShopItemView> shopItems = new List<ShopItemView>();

        [SerializeField] private Transform itemsParent;

        public void Show(IEnumerable<ShopItem> items)
        {
        }
    }
}