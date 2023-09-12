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
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Buy
{
    [DisallowMultipleComponent]
    public sealed class BuyButton : MonoBehaviour
    {
        public event Action OnClick;

        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;

        [SerializeField] private Color lockColor;
        [SerializeField] private Color unlockColor;

        [SerializeField, Range(0f, 1f)] private float lockAnimationDuration = 0.4f;
        [SerializeField, Range(0.5f, 5f)] private float lockAnimationStrenght = 2f;

        private bool isLock;

        private void OnEnable() =>
            button.onClick.AddListener(OnButtonClick);

        private void OnDisable() =>
            button.onClick.RemoveListener(OnButtonClick);

        public void UpdateText(int price) =>
            text.text = $"{price}";

        public void Lock()
        {
            isLock = true;
            text.color = lockColor;
        }

        public void Unlock()
        {
            isLock = false;
            text.color = unlockColor;
        }

        private void OnButtonClick()
        {
            if (isLock)
            {
                transform.DOShakePosition(lockAnimationDuration, lockAnimationStrenght);

                return;
            }

            OnClick?.Invoke();
        }
    }
}