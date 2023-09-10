using System;
using System.Collections.Generic;
using System.Linq;

namespace RimuruDev.Internal.Codebase.Utilities.Extensions
{
    public static class ActionExtensions
    {
        public static void UnsubscribeAndRemoveAll(this Action action, List<Action> listeners)
        {
            if (action == null || listeners == null)
                return;

            foreach (var listener in listeners.Where(listener => listener != null && listener == action).ToList())
            {
                action -= listener;
                listeners.Remove(listener);
            }
        }

        public static void UnsubscribeAndRemoveAndClearAll(this Action action, List<Action> listeners)
        {
            if (action == null || listeners == null)
                return;

            foreach (var listener in listeners.Where(listener => listener != null && listener == action).ToList())
            {
                action -= listener;
                listeners.Remove(listener);
            }

            listeners.Clear();
        }

        public static void UnsubscribeAll(this Action action, IEnumerable<Action> listeners)
        {
            if (action == null || listeners == null)
                return;

            foreach (var listener in listeners.Where(listener => listener != null && listener == action).ToList())
            {
                action -= listener;
            }
        }
    }
}