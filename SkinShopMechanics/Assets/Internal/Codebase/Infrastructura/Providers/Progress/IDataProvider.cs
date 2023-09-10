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

namespace RimuruDev.Internal.Codebase.Infrastructura.Providers.Progress
{
    public interface IDataProvider
    {
        public void Save();
        public bool TryLoad();
    }
}