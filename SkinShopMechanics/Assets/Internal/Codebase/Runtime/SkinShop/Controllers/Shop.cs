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

using NaughtyAttributes;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Panels;
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Controllers
{
    [DisallowMultipleComponent]
    public sealed class Shop : MonoBehaviour
    {
        [SerializeField, Expandable] private ShopContent contentItems;

        [SerializeField] private ShopCategoryButton characterSkinButtons;
        [SerializeField] private ShopCategoryButton mazeSkinButtons;

        [SerializeField] private ShopPanel shopPanel;

        private void OnEnable()
        {
            characterSkinButtons.OnClick += OnCharacterSkinsButtonClick;
            mazeSkinButtons.OnClick += OnMazeSkinsButtonClick;
        }

        private void OnDisable()
        {
            characterSkinButtons.OnClick -= OnCharacterSkinsButtonClick;
            mazeSkinButtons.OnClick -= OnMazeSkinsButtonClick;
        }

        private void OnCharacterSkinsButtonClick()
        {
            mazeSkinButtons.Unselect();
            characterSkinButtons.Select();
            shopPanel.Show(contentItems.CharacterSkinItem);
        }

        private void OnMazeSkinsButtonClick()
        {
            mazeSkinButtons.Select();
            characterSkinButtons.Unselect();
            shopPanel.Show(contentItems.MazeSkinItem);
        }
    }
}