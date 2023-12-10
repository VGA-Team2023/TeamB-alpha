using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class DarkenActor : ICommand
        {
            private int _targetId;

            public DarkenActor(string[] commandArgs)
            {
                if(int.TryParse(commandArgs[0], out int targetId))
                {
                    _targetId = targetId;
                }
                else
                {
                    Debug.Log($"{commandArgs[0]}をintに直せませんでした");
                }
            }

            private async UniTask Darken(int targetId)
            {
                var actorPos = (ActorPos)Enum.ToObject(typeof(ActorPos), targetId);

                var targetActor = NovelData.Current.ActiveActor[(int)actorPos];

                var initScale = targetActor.transform.localScale;

                var toScale = new Vector3(0.45f, 0.45f, 0.45f);

                targetActor.transform.localScale = Vector3.Lerp(initScale, toScale, 1f);

                targetActor.color = NovelData.Current.DarkColor;

                await UniTask.CompletedTask;
            }
#pragma warning disable 1998
            public async UniTask RunCommand(CancellationToken token = default)
            {
                await Darken(_targetId);
            }
#pragma warning restore 1998
        }
    }
}

