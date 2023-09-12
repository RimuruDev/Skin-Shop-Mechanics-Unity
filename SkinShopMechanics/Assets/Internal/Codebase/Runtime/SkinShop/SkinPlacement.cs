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

using RimuruDev.Internal.Codebase.Runtime.Common;
using UnityEngine;

namespace RimuruDev.Internal.Codebase.Runtime.SkinShop
{
    [DisallowMultipleComponent]
    public sealed class SkinPlacement : MonoBehaviour
    {
        private const string RenderLayer = "SkinRender";

        [SerializeField] private Rotator rotator;
        private GameObject currentModel;

        public void InstantiateModel(GameObject model)
        {
            if (currentModel != null)
                Destroy(currentModel);

            rotator.ResetRotation();

            currentModel = Instantiate(model, transform);

            var childs = currentModel.GetComponentsInChildren<Transform>();

            foreach (var child in childs)
                child.gameObject.layer = LayerMask.NameToLayer(RenderLayer);
        }
    }
}