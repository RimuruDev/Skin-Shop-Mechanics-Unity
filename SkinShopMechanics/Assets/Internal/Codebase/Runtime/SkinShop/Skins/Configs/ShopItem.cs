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

using UnityEngine;
using NaughtyAttributes;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs
{
    public abstract class ShopItem : ScriptableObject
    {
        [field: SerializeField] public GameObject Model { get; private set; }

        [field: SerializeField, ShowAssetPreview]
        public Sprite Image { get; private set; }

        [field: SerializeField, Range(0, 10000)]
        public int Price { get; private set; }
    }
}