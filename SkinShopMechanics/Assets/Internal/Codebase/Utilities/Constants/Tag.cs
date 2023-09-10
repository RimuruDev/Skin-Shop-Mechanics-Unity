// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System.Diagnostics.CodeAnalysis;

namespace RimuruDev.Internal.Codebase.Utilities.Constants
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public readonly struct Tag
    {
        public const string Untagged = nameof(Untagged);
        public const string Respawn = nameof(Respawn);
        public const string Finish = nameof(Finish);
        public const string EditorOnly = nameof(EditorOnly);
        public const string MainCamera = nameof(MainCamera);
        public const string Player = nameof(Player);
        public const string GameController = nameof(GameController);
        public const string Ground = nameof(Ground);
    }
}