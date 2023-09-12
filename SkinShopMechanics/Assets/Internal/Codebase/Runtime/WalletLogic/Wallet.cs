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
using RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.WalletLogic
{
    public class Wallet
    {
        public event Action<int> OnCoinsChanged;
        private readonly IPersistenData persistenData;

        public Wallet(IPersistenData persistenData) =>
            this.persistenData = persistenData ?? throw new ArgumentNullException(nameof(persistenData));

        public int GetCurrentCoins() =>
            persistenData.PlayerData.Currency;

        public void AddCoins(int currency)
        {
            try
            {
                if (currency < 0)
                    throw new ArgumentOutOfRangeException(nameof(currency));

                persistenData.PlayerData.Currency += currency;

                OnCoinsChanged?.Invoke(persistenData.PlayerData.Currency);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Debug.LogError($"ArgumentOutOfRangeException. Value: {currency} Canceling the addition of coins.\n" +
                               $"{ex.Source}");

                OnCoinsChanged?.Invoke(persistenData.PlayerData.Currency);
            }
        }

        public bool IsEnought(int currency)
        {
            try
            {
                if (currency < 0)
                    throw new ArgumentOutOfRangeException(nameof(currency));

                return persistenData.PlayerData.Currency >= currency;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Debug.LogError($" Value: {currency} Current currency {persistenData.PlayerData.Currency} > 0\n" +
                               $"{ex.Source}");
                return true;
            }
        }

        public void Send(int currency)
        {
            try
            {
                if (currency < 0)
                    throw new ArgumentOutOfRangeException(nameof(currency));

                persistenData.PlayerData.Currency -= currency;

                OnCoinsChanged?.Invoke(persistenData.PlayerData.Currency);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Debug.LogError(
                    $"ArgumentOutOfRangeException. Value: {currency} Canceling the expenditures of coins.\n" +
                    $"{ex.Source}");

                OnCoinsChanged?.Invoke(persistenData.PlayerData.Currency);
            }
        }
    }
}