// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System;

namespace RimuruDev.Internal.Codebase.Utilities.Exceptions
{
    public sealed class AssetLoadException : Exception
    {
        public AssetLoadException(string path) : base(path)
        {
        }
    }
}