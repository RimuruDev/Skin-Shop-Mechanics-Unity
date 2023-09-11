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
using NaughtyAttributes;
using RimuruDev.Internal.Codebase.Infrastructura.Factorys.ShopItems;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.View;
using RimuruDev.Internal.Codebase.Utilities.Extensions;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Panels
{
    [DisallowMultipleComponent]
    public class ShopPanel : MonoBehaviour
    {
        private readonly IList<ShopItemView> shopItems = new List<ShopItemView>();

        [SerializeField] private Transform itemsParent;
        [SerializeField, Expandable] private ShopItemViewFactory factory;

        public void Show(IEnumerable<ShopItem> items)
        {
            items.CheckNull(factory, itemsParent);

            ClearAll();

            foreach (var item in items)
            {
                var spawnedItem = factory.Create(item, itemsParent);

                spawnedItem.OnClick += OnItemViewClick;

                spawnedItem.UnSelect();
                spawnedItem.UnHighlight();

                // Check open/close skin
                
                
                shopItems.Add(spawnedItem);
            }
        }

        private void OnItemViewClick(ShopItemView view)
        {
        }

        private void ClearAll()
        {
            foreach (var item in shopItems.Where(item => item != null).ToList())
            {
                item.OnClick -= OnItemViewClick;
                Destroy(item.gameObject);
            }

            shopItems.Clear();
        }
    }
}