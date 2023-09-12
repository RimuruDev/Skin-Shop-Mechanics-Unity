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

namespace RimuruDev.Internal.Codebase.Runtime.GameplayScene.Hero
{
    [DisallowMultipleComponent]
    public sealed class Character : MonoBehaviour
    {
        public void Initialize()
        {
            Debug.Log("Initialize Character");
        }
    }
}