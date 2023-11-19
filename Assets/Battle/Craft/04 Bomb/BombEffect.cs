using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Bomb Effect", menuName = "ScriptableObjects/Craftable Effect/Bomb Effect", order = 0)]
            public class BombEffect : CraftableEffect
            {
                [SerializeField]
                private BombParam[] _bombParams;

                public BombParam[] BombParams => _bombParams;

                public override CraftableParameter[] Parameters => _bombParams;

                public override CraftType CraftType => CraftType.Bomb;

                public override void RequestEffect(AllyType user, int level, CancellationToken token = default)
                {
                    var index = level - 1;
                    var param = _bombParams[index];
                    PlayEffect(param, token);
                }

                private async void PlayEffect(BombParam param, CancellationToken token)
                {
                    StartEffect(param);

                    float timer = 0f;

                    while (timer < param.EffectDuration)
                    {
                        try
                        {
                            timer += Time.deltaTime; // TODO: GameSpeed掛ける
                            await UniTask.Yield(token);
                        }
                        catch (OperationCanceledException)
                        {
                            Debug.Log("Canceled");
                            return;
                        }
                    }

                    EndEffect(param);
                }

                private void StartEffect(BombParam param)
                {
                    Debug.Log("start bomb");
                }

                private void EndEffect(BombParam param)
                {
                    Debug.Log("end bomb");
                }
            }
        }
    }
}