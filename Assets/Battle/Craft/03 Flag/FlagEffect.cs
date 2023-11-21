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

                private CancellationTokenSource _effectCancellationTokenSource;

                public FlagParam[] FlagParams => _flagParams;
                public override CraftableParameter[] Parameters => _flagParams;
                public override CraftType CraftType => CraftType.Flag;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _flagParams[index];

                    _effectCancellationTokenSource?.Cancel();
                    _effectCancellationTokenSource = new CancellationTokenSource();

                    var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_effectCancellationTokenSource.Token, token);

                    PlayEffect(param, linkedTokenSource.Token);
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
                            break;
                        }
                    }

                    EndEffect(param);
                }

                private void StartEffect(FlagParam param)
                {
                    if (!PlacedAllyContainer.Current)
                    {
                        Debug.Log($"PlacedAllyContainer.Current is None");
                        return;
                    }
                    foreach (var ally in PlacedAllyContainer.Current.PlacedAllies)
                    {
                        ally.MultiplierParams.Add(AllyBattleParameter.CreateOne(attackPower: param.PowerupAmount));
                    }
                }

                private void EndEffect(FlagParam param)
                {
                    if (!PlacedAllyContainer.Current)
                    {
                        Debug.Log($"PlacedAllyContainer.Current is None");
                        return;
                    }
                    foreach (var ally in PlacedAllyContainer.Current.PlacedAllies)
                    {
                        ally.MultiplierParams.Remove(AllyBattleParameter.CreateOne(attackPower: param.PowerupAmount));
                    }
                }
            }
        }
    }
}