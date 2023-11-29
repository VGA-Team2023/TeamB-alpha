// 日本語対応
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class ActorAction : ICommand
        {
            private string _actorName;    // アクター名
            private string _actionName;   // アクション名
            private string[] _actionArgs; // 引数

            private Func<string[], UniTask> _action;

            public ActorAction(string[] parametorData)
            {
                _actorName = parametorData[0];
                _actionName = parametorData[1];
                _actionArgs = parametorData[2..];

                switch (_actionName)
                {
                    case nameof(Fade): _action = Fade; break;
                    case nameof(Move): _action = Move; break;
                    default: throw new MissingMethodException(_actionName);
                }
            }

            public async UniTask RunCommand(CancellationToken token = default)
            {
                await _action.Invoke(_actionArgs);
            }

            #region actions
#pragma warning disable 1998
            private async UniTask Fade(string[] args)
            {
                var actorName = _actorName;
                var target = float.Parse(args[0]);
                var duration = float.Parse(args[1]);
            }

            private async UniTask Move(string[] args)
            {
                var actorName = _actorName;
                var targetPointX = float.Parse(args[0]);
                var targetPointY = float.Parse(args[1]);
                var targetPointZ = float.Parse(args[2]);
                var duration = float.Parse(args[3]);
            }
#pragma warning restore 1998
            #endregion
        }
    }
}