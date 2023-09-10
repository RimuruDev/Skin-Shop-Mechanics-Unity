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
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop
{
    [DisallowMultipleComponent]
    public sealed class ShopCategoryButton : MonoBehaviour
    {
        public event Action OnClick;

        [SerializeField] private Button button;

        [SerializeField] private Image image;

        [SerializeField] private Color selectColor;
        [SerializeField] private Color unselectColor;

        private void OnEnable() =>
            button.onClick.AddListener(Click);

        private void OnDisable() =>
            button.onClick.RemoveListener(Click);

        public void Select() => image.color = selectColor;
        public void Unselect() => image.color = unselectColor;

        private void Click() =>
            OnClick?.Invoke();
    }
}