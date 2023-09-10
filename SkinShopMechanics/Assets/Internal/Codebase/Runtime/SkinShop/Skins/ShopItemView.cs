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
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public sealed class ShopItemView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<ShopItemView> OnClick;

        [SerializeField, ShowAssetPreview] private Sprite standardBackground;
        [SerializeField, ShowAssetPreview] private Sprite higlightBackground;
        
        [SerializeField] private Image contentImage;
        [SerializeField] private Image lockImage;
        [SerializeField] private Image selectionText;

        private Image backgroundImage;

        public void OnPointerClick(PointerEventData eventData) =>
            OnClick?.Invoke(this);
    }
}