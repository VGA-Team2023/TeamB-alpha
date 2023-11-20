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
            [CreateAssetMenu(fileName = "Flag Effect", menuName = "ScriptableObjects/Craftable Effect/", order = 0)]
            public class FlagEffect : CraftableEffect
            {
                [SerializeField]
                private FlagParam[] _flagParams;

                public FlagParam[] FlagParams => _flagParams;
                public override CraftableParameter[] Parameters => _flagParams;

                public override CraftType CraftType => CraftType.Flag;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _flagParams[index];
                    PlayEffect(param, token);
                }

                private async void PlayEffect(FlagParam param, CancellationToken token)
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

                private void StartEffect(FlagParam param)
                {
                    Debug.Log("start flag");
                }

                private void EndEffect(FlagParam param)
                {
                    Debug.Log("end flag");
                }
            }
        }
    }
}