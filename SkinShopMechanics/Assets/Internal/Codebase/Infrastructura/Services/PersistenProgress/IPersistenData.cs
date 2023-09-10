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

using RimuruDev.Internal.Codebase.Infrastructura.Storages;

namespace RimuruDev.Internal.Codebase.Infrastructura.Services.PersistenProgress
{
    public interface IPersistenData
    {
        public PlayerData PlayerData { get; set; }
    }
}