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

                private CancellationTokenSource _effectCancellationTokenSource;

                public BombParam[] BombParams => _bombParams;

                public override CraftableParameter[] Parameters => _bombParams;

                public override CraftType CraftType => CraftType.Bomb;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _bombParams[index];

                    _effectCancellationTokenSource?.Cancel();
                    _effectCancellationTokenSource = new CancellationTokenSource();

                    var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_effectCancellationTokenSource.Token, token);

                    PlayEffect(user, param, linkedTokenSource.Token);
                }

                private async void PlayEffect(AllyController user, BombParam param, CancellationToken token)
                {
                    StartEffect(user, param);

                    float timer = 0f;

                    while (timer < param.EffectDuration)
                    {
                        try
                        {
                            timer += Time.deltaTime * GameSpeedController.CurretGameSpeed;
                            await UniTask.Yield(token);
                        }
                        catch (OperationCanceledException)
                        {
                            Debug.Log("Canceled");
                            break;
                        }
                    }

                    EndEffect(user, param);
                }

                private IAllyAttack _originalAttackStyle; // 元々の攻撃方法。

                private void StartEffect(AllyController user, BombParam param)
                {
                    // BombAttackの取得。
                    if (!user.TryGetComponent(out AttackStyleSingleSelecter selecter)) return;
                    if (selecter.Select is not BombAttack) return;

                    // 元々の攻撃方法を保存する。
                    var currentAttackStyle = user.AttackController.CurrentAttackStyle;
                    if (currentAttackStyle is not BombAttack)
                        _originalAttackStyle = currentAttackStyle;

                    // 攻撃方法の変更。
                    user.AttackController.ChangeAttackStyle(selecter.Select);

                }

                private void EndEffect(AllyController user, BombParam param)
                {
                    user.AttackController.ChangeAttackStyle(_originalAttackStyle);
                }
            }
        }
    }
}