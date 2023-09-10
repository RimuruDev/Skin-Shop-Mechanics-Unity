using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RimuruDev.Internal.Codebase.Utilities.Extensions
{
    public static class UnityComponentExtensions
    {
        public static bool TryGetComponentInChildren<TComponent>(
            this Component @object,
            out TComponent findComponent,
            bool includeInactive = false)
            where TComponent : Object
        {
            findComponent = null;

            var component = @object.GetComponentInChildren<TComponent>(includeInactive);

            if (@object == null)
                return false;

            if (component == null)
                return false;

            findComponent = component;
            return true;
        }

        public static bool TryGetComponentInChildrenAndInvoke<TComponent>(
            this Component @object,
            out TComponent findComponent,
            Action action,
            bool includeInactive = false)
            where TComponent : Object
        {
            findComponent = null;

            var component = @object.GetComponentInChildren<TComponent>(includeInactive);

            if (@object == null)
                return false;

            if (component == null)
                return false;

            findComponent = component;

            action?.Invoke();

            return true;
        }

        public static bool TryGetComponentInParent<TComponent>(
            this Component @object,
            out TComponent findComponent,
            bool includeInactive = false)
            where TComponent : Object
        {
            findComponent = null;

            var component = @object.GetComponentInParent<TComponent>(includeInactive);

            if (@object == null)
                return false;

            if (component == null)
                return false;

            findComponent = component;
            return true;
        }

        public static bool TryGetComponentFullHierarchy<TComponent>(
            this Component @object,
            out TComponent findComponent,
            bool includeInactive = false)
            where TComponent : Component
        {
            findComponent = null;

            if (@object == null)
                return false;

            var component = @object.GetComponent<TComponent>();

            if (component != null)
            {
                findComponent = component;
                return true;
            }

            var gameObject = @object.gameObject;

            if (gameObject == null || gameObject.transform.parent == null)
                return false;

            var parentComponent = gameObject.transform.parent.GetComponentInParent<TComponent>(includeInactive);

            if (parentComponent == null)
                return false;

            findComponent = parentComponent;
            return true;
        }
    }
}