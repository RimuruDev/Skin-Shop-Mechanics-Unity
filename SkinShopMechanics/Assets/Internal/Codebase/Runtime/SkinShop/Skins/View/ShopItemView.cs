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
using NaughtyAttributes;
using RimuruDev.Internal.Codebase.Runtime.Common.Values.Implementations;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Utilities.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.View
{
    [SelectionBase]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public sealed class ShopItemView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<ShopItemView> OnClick;

        [SerializeField, ShowAssetPreview] private Sprite standardBackground;
        [SerializeField, ShowAssetPreview] private Sprite higlightBackground;

        [SerializeField] private IntValueView priceView;

        [SerializeField] private Image contentImage;
        [SerializeField] private Image lockImage;
        [SerializeField] private Image selectionText;

        private Image backgroundImage;

        public ShopItem Item { get; private set; }
        public bool IsLoock { get; private set; }

        public int Price => Item.Price;
        public GameObject Model => Item.Model;

        public void Initialize(ShopItem shopItem)
        {
            Validate.Null(shopItem, standardBackground);

            backgroundImage = GetComponent<Image>();
            backgroundImage.sprite = standardBackground;

            Item = shopItem;
            contentImage.sprite = Item.Image;

            priceView.Show(Price);
        }

        public void OnPointerClick(PointerEventData eventData) =>
            OnClick?.Invoke(this);

        public void Lock()
        {
            IsLoock = true;
            lockImage.gameObject.SetActive(IsLoock);
            priceView.Show(Price);
        }

        public void Unlock()
        {
            IsLoock = false;
            lockImage.gameObject.SetActive(IsLoock);
            priceView.Hide();
        }

        public void Select() => selectionText.gameObject.SetActive(true);
        public void UnSelect() => selectionText.gameObject.SetActive(false);

        public void Highlight() => backgroundImage.sprite = higlightBackground;
        public void UnHighlight() => backgroundImage.sprite = standardBackground;
    }
}