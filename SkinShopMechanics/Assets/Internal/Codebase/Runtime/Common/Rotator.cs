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

namespace RimuruDev.Internal.Codebase.Runtime.Common
{
    [DisallowMultipleComponent]
    public sealed class Rotator : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)] private float rotationSpeed;

        private float currentRotation = 0;

        private void Update()
        {
            currentRotation -= Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);
        }

        public void ResetRotation() =>
            currentRotation = 0;
    }
}