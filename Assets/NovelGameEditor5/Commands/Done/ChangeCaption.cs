// 日本語対応
using Cysharp.Threading.Tasks;
using System.Threading;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class ChangeCaption : ICommand
        {
            private string _caption;

            public ChangeCaption(string[] parametorData)
            {
                _caption = parametorData[0];
            }

#pragma warning disable 1998
            public async UniTask RunCommand(CancellationToken token = default)
            {
                NovelData.Current.Caption.text = _caption;
            }
#pragma warning restore 1998
        }
    }
}