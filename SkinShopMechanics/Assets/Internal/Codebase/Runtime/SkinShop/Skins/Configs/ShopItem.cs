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

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs
{
    [CreateAssetMenu(fileName = nameof(ShopItem), menuName = "StaticData/" + nameof(ShopItem), order = 0)]
    public sealed class ShopItem : ScriptableObject
    {
        [field: SerializeField] public GameObject Model { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
    }
}