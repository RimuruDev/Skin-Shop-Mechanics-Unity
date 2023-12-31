﻿// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using System.Diagnostics.CodeAnalysis;
using RimuruDev.Internal.Codebase.Runtime.WalletLogic;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Panels;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.View;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using RimuruDev.Internal.Codebase.Infrastructura.Providers.Progress;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Buy;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Visitors.Implementations;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Controllers
{
    [DisallowMultipleComponent]
    public sealed class Shop : MonoBehaviour
    {
        [SerializeField, Expandable] private ShopContent contentItems;

        [SerializeField] private ShopCategoryButton characterSkinButtons;
        [SerializeField] private ShopCategoryButton mazeSkinButtons;

        [SerializeField] private BuyButton buyButton;
        [SerializeField] private Button selectedButton;
        [SerializeField] private Image selectedText;

        [SerializeField] private ShopPanel shopPanel;
        [SerializeField] private SkinPlacement skinPlacement;

        [SerializeField] private Camera modelCamera;
        [SerializeField] private Transform characterCategoryCameraPosition;
        [SerializeField] private Transform mazeCategoryCameraPosition;

        private IDataProvider dataProvider;
        private ShopItemView previewedItem;
        private Wallet wallet;

        private SkinSelector skinSelector;
        private SkinUncloker skinUncloker;
        private OpenSkinsChecker openSkinsChecker;
        private SelectedSkinsChecker selectedSkinsChecker;

        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        public void Initialize(
            Wallet wallet,
            IDataProvider dataProvider,
            OpenSkinsChecker openSkinsChecker,
            SelectedSkinsChecker selectedSkinsChecker,
            SkinSelector skinSelector,
            SkinUncloker skinUncloker)
        {
            this.wallet = wallet;
            this.dataProvider = dataProvider;
            this.openSkinsChecker = openSkinsChecker;
            this.selectedSkinsChecker = selectedSkinsChecker;
            this.skinSelector = skinSelector;
            this.skinUncloker = skinUncloker;

            shopPanel.Initialize(this.openSkinsChecker, this.selectedSkinsChecker);

            shopPanel.OnItemViewClicked += OnItemViewClicked;

            OnCharacterSkinsButtonClick();
        }

        private void OnEnable()
        {
            characterSkinButtons.OnClick += OnCharacterSkinsButtonClick;
            mazeSkinButtons.OnClick += OnMazeSkinsButtonClick;

            buyButton.OnClick += OnBuyButtonClick;
            selectedButton.onClick.AddListener(OnSelectionButtonClick);
        }

        private void OnDisable()
        {
            characterSkinButtons.OnClick -= OnCharacterSkinsButtonClick;
            mazeSkinButtons.OnClick -= OnMazeSkinsButtonClick;
            shopPanel.OnItemViewClicked -= OnItemViewClicked;

            buyButton.OnClick -= OnBuyButtonClick;
            selectedButton.onClick.RemoveListener(OnSelectionButtonClick);
        }

        private void OnCharacterSkinsButtonClick()
        {
            mazeSkinButtons.Unselect();
            characterSkinButtons.Select();

            UpdateCameraTransform(characterCategoryCameraPosition);

            shopPanel.Show(contentItems.CharacterSkinItem);
        }

        private void OnMazeSkinsButtonClick()
        {
            mazeSkinButtons.Select();
            characterSkinButtons.Unselect();

            UpdateCameraTransform(mazeCategoryCameraPosition);

            shopPanel.Show(contentItems.MazeSkinItem);
        }

        private void SelectSkin()
        {
            skinSelector.Visit(previewedItem.Item);
            shopPanel.Select(previewedItem);
            ShowSelectedText();
        }

        private void OnBuyButtonClick()
        {
            if (wallet.IsEnought(previewedItem.Price))
            {
                wallet.Send(previewedItem.Price);

                skinUncloker.Visit(previewedItem.Item);

                SelectSkin();

                previewedItem.Unlock();

                dataProvider.Save();
            }
        }

        private void OnSelectionButtonClick()
        {
            SelectSkin();

            dataProvider.Save();
        }

        private void UpdateCameraTransform(Transform transform) =>
            modelCamera.transform.SetPositionAndRotation(transform.position, transform.rotation);

        private void OnItemViewClicked(ShopItemView itemView)
        {
            previewedItem = itemView;
            skinPlacement.InstantiateModel(previewedItem.Model);

            openSkinsChecker.Visit(previewedItem.Item);

            if (openSkinsChecker.IsOpened)
            {
                selectedSkinsChecker.Visit(previewedItem.Item);

                if (selectedSkinsChecker.IsSelected)
                {
                    ShowSelectedText();
                    return;
                }

                ShowSelectionButton();
            }
            else
                ShoweBuyButton(previewedItem.Price);
        }

        private void ShowSelectionButton()
        {
            selectedButton.gameObject.SetActive(true);
            HideBuyButton();
            HideSelectedText();
        }

        private void ShowSelectedText()
        {
            selectedText.gameObject.SetActive(true);
            HideSelectionButton();
            HideBuyButton();
        }

        private void ShoweBuyButton(int price)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.UpdateText(price);

            if (wallet.IsEnought(price))
                buyButton.Unlock();
            else
                buyButton.Lock();

            HideSelectedText();
            HideSelectionButton();
        }

        private void HideBuyButton() =>
            buyButton.gameObject.SetActive(false);

        private void HideSelectionButton() =>
            selectedButton.gameObject.SetActive(false);

        private void HideSelectedText() =>
            selectedText.gameObject.SetActive(false);
    }
}