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
using RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Configs;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop.Skins.Character
{
    [CreateAssetMenu(fileName = nameof(CharacterSkinItem), menuName = "StaticData/Shop/" + nameof(CharacterSkinItem), order = 0)]
    public sealed class CharacterSkinItem : ShopItem
    {
        [field: SerializeField] public CharacterSkins SkinType { get; private set; }
    }
}