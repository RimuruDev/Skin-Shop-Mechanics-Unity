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
using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using RimuruDev.Internal.Codebase.Utilities.Extensions;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.View;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Infrastructura.Factorys.ShopItems;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Implementations;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Panels
{
    [DisallowMultipleComponent]
    public sealed class ShopPanel : MonoBehaviour
    {
        public event Action<ShopItemView> OnItemViewClicked;

        private readonly IList<ShopItemView> shopItems = new List<ShopItemView>();

        [SerializeField] private Transform itemsParent;
        [SerializeField, Expandable] private ShopItemViewFactory factory;

        private OpenSkinsChecker openSkinsChecker;
        private SelectedSkinsChecker selectedSkinsChecker;

        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        public void Initialize(OpenSkinsChecker openSkinsChecker, SelectedSkinsChecker selectedSkinsChecker)
        {
            Validate.Null(openSkinsChecker, selectedSkinsChecker);

            this.openSkinsChecker = openSkinsChecker;
            this.selectedSkinsChecker = selectedSkinsChecker;
        }

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

                openSkinsChecker.Visit(spawnedItem.Item);

                if (openSkinsChecker.IsOpened)
                {
                    selectedSkinsChecker.Visit(spawnedItem.Item);

                    if (selectedSkinsChecker.IsSelected)
                    {
                        spawnedItem.Select();
                        spawnedItem.Highlight();
                        OnItemViewClicked?.Invoke(spawnedItem);
                    }

                    spawnedItem.Unlock();
                }
                else
                    spawnedItem.Lock();

                shopItems.Add(spawnedItem);
            }
        }

        public void Select(ShopItemView itemView)
        {
            foreach (var item in shopItems)
                item.UnSelect();
            
            itemView.Select();
        }

        private void OnItemViewClick(ShopItemView view)
        {
            Highlight(view);

            OnItemViewClicked?.Invoke(view);
        }

        private void Highlight(ShopItemView shopItemView)
        {
            foreach (var item in shopItems)
                item.UnHighlight();

            shopItemView.Highlight();
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