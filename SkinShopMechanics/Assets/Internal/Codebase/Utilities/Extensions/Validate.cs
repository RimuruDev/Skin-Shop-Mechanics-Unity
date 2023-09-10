// Resharper disable All
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