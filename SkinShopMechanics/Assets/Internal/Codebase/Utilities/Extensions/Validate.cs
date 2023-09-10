// Resharper disable All

using System;
using System.Linq;

public static class Validate
{
    public static void Null(params object[] objs)
    {
        if (objs.Any(obj => obj == null))
            throw new NullReferenceException(nameof(objs));
    }

    public static void CheckNull(this object obj)
    {
        if (obj == null)
            throw new NullReferenceException(nameof(obj));
    }
}