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
using TMPro;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.Common.Values.Base
{
    [DisallowMultipleComponent]
    public class ValueView<TValue> : MonoBehaviour where TValue : IConvertible
    {
        [SerializeField] private TMP_Text valueText;

        public void Show(TValue value)
        {
            if (valueText == null)
                throw new NullReferenceException(nameof(valueText));

            gameObject.SetActive(true);
            valueText.text = $"{value}";
        }

        public void Hide() =>
            gameObject.SetActive(false);
    }
}