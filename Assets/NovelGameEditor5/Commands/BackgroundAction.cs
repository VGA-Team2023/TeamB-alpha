// 日本語対応
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class BackgroundAction : ICommand
        {
            private string _backgroundName;
            private string _actionName;
            private string[] _args;

            private Func<string[], UniTask> _action;

            public BackgroundAction(string[] parametorData)
            {
                _backgroundName = parametorData[0];
                _actionName = parametorData[1];
                _args = parametorData[2..];

                switch (_actionName)
                {
                    case nameof(Shake): _action = Shake; break;
                    case nameof(Fade): _action = Fade; break;
                    default: throw new MissingMethodException(_actionName);
                }
            }
            public async UniTask RunCommand(CancellationToken token = default)
            {
                await _action.Invoke(_args);
            }


#pragma warning disable 1998
            private async UniTask Shake(string[] args)
            {

            }

            private async UniTask Fade(string[] args)
            {

            }
#pragma warning restore 1998
        }
    }
}