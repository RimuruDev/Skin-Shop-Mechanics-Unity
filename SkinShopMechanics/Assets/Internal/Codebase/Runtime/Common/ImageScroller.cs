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
using UnityEngine.UI;

namespace RimuruDev.Internal.Codebase.Runtime.Common
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RawImage))]
    public sealed class ImageScroller : MonoBehaviour
    {
        private RawImage rawImage;

        [SerializeField, Range(0f, 10)] private float scrollSpeed = 0.1f;
        [SerializeField, Range(-1f, 1f)] private float xDirection = 0.1f;
        [SerializeField, Range(-1f, 1f)] private float yDirection = 0.1f;

        private void Awake() =>
            rawImage = GetComponent<RawImage>();

        private void Update() =>
            ApplyScrolling();

        private void ApplyScrolling() =>
            rawImage.uvRect = new Rect(CalculateNewPosition(), rawImage.uvRect.size);

        private Vector2 CalculateNewPosition() =>
            rawImage.uvRect.position + CalculateNewDirection() * Time.deltaTime;

        private Vector2 CalculateNewDirection() =>
            new(-xDirection * scrollSpeed, yDirection * scrollSpeed);
    }
}