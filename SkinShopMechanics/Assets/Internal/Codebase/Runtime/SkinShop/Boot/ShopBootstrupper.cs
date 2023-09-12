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
using RimuruDev.Internal.Codebase.Infrastructura.Providers.Progress;
using RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress;
using RimuruDev.Internal.Codebase.Infrastructura.Storages;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Controllers;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Implementations;
using RimuruDev.Internal.Codebase.Runtime.WalletLogic;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Boot
{
    [DisallowMultipleComponent]
    public sealed class ShopBootstrupper : MonoBehaviour
    {
        [SerializeField] private Shop shop;
        [SerializeField] private WalletView walletView;

        private IDataProvider dataProvider;
        private IPersistenData persistenData;

        private Wallet wallet;

        private void Awake()
        {
            InitializeData();
            InitializeWallet();
            InitializeShop();
        }

        private void InitializeData()
        {
            persistenData = new PersistenData();
            dataProvider = new DataLocalDataProvider(persistenData);

            LoadDataOrInit();
        }

        private void InitializeWallet()
        {
            wallet = new Wallet(persistenData);
            walletView.Initialize(wallet);
        }

        private void InitializeShop()
        {
            var openSkinsChecker = new OpenSkinsChecker(persistenData);
            var selectedSkinsChecker = new SelectedSkinsChecker(persistenData);
            var skinSelector = new SkinSelector(persistenData);
            var skinUncloker = new SkinUncloker(persistenData);

            shop.Initialize(wallet, dataProvider, openSkinsChecker, selectedSkinsChecker, skinSelector, skinUncloker);
        }

        private void LoadDataOrInit()
        {
            if (dataProvider.TryLoad() == false)
                persistenData.PlayerData = new PlayerData();
        }
    }
}