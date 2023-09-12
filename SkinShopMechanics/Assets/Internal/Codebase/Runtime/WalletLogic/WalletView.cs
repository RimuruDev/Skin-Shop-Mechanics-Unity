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

using TMPro;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.WalletLogic
{
    [DisallowMultipleComponent]
    public sealed class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private Wallet wallet;

        public void Initialize(Wallet wallet)
        {
            this.wallet = wallet;

            UpdateValues(wallet.GetCurrentCoins());

            wallet.OnCoinsChanged += UpdateValues;
        }

        private void OnDestroy() =>
            wallet.OnCoinsChanged -= UpdateValues;

        private void UpdateValues(int curency) =>
            text.text = $"{curency}";
    }
}