using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class DisplayActor : ICommand
        {
            private int _actorId;
            private int _actorPos;

            public DisplayActor(string[] commandArgs)
            {
                if (int.TryParse(commandArgs[0], out int actorId))
                {
                    _actorId = actorId;
                }
                else
                {
                    Debug.Log($"{commandArgs[0]}をintに直せませんでした");
                }

                if (int.TryParse(commandArgs[1], out int actorPos))
                {
                    _actorPos = actorPos;
                }
                else
                {
                    Debug.Log($"{commandArgs[1]}をintに直せませんでした");
                }
            }

            private async UniTask Display(int actorId, int actorPos)
            {
                var talkingActorSize = NovelData.Current.TalkingActorSize;
                var talkingActorColor = new Color(1, 1, 1, 1);

                NovelData.Current.ActiveActor[actorPos].transform.localScale = talkingActorSize;
                NovelData.Current.ActiveActor[actorPos].color = talkingActorColor;
                NovelData.Current.ActiveActor[actorPos].sprite = NovelData.Current.AllyUnitSprites[actorId];

                await UniTask.CompletedTask;
            }

            public async UniTask RunCommand(CancellationToken token = default)
            {
                await Display(_actorId, _actorPos);
            }
        }
    }
}

