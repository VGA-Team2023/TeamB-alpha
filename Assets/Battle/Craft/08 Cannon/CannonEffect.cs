using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TeamB_TD.Battle.Unit.Ally;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Cannon Effect", menuName = "ScriptableObjects/Craftable Effect/Cannon Effect", order = 0)]
            public class CannonEffect : CraftableEffect
            {
                [SerializeField]
                private CannonParam[] _cannonParams;

                private CancellationTokenSource _effectCancellationTokenSource;

                public CannonParam[] CannonParams => _cannonParams;
                public override CraftableParameter[] Parameters => _cannonParams;

                public override CraftType CraftType => CraftType.Cannon;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _cannonParams[index];

                    _effectCancellationTokenSource?.Cancel();
                    _effectCancellationTokenSource = new CancellationTokenSource();

                    var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_effectCancellationTokenSource.Token, token);

                    PlayEffect(user, param, linkedTokenSource.Token);
                }

                private async void PlayEffect(AllyController user, CannonParam param, CancellationToken token)
                {
                    StartEffect(user, param);

                    float timer = 0f;

                    while (timer < param.EffectorDuration)
                    {
                        try
                        {
                            timer += Time.deltaTime * GameSpeedController.CurretGameSpeed;
                            await UniTask.Yield(token);
                        }
                        catch (OperationCanceledException)
                        {
                            // Debug.Log("Canceled");
                            return;
                        }
                    }

                    EndEffect(user, param);
                }

                private IAllyAttack _originalAttackStyle; // 元々の攻撃方法。

                private void StartEffect(AllyController user, CannonParam param)
                {
                    // CannnonAttackの取得。
                    if (!user.TryGetComponent(out AttackStyleSingleSelecter selecter)) return;
                    var cannonAttack = selecter.Select as CannnonAttack;
                    if (cannonAttack == null) return;

                    // 元々の攻撃方法を保存する。
                    var currentAttackStyle = user.AttackController.CurrentAttackStyle;
                    if (currentAttackStyle is not CannnonAttack)
                        _originalAttackStyle = currentAttackStyle;

                    // 攻撃方法の変更。
                    user.AttackController.ChangeAttackStyle(cannonAttack);
                    cannonAttack.SetMultiplication(param.PowerupAmount);
                }

                private void EndEffect(AllyController user, CannonParam param)
                {
                    // Debug.Log("end");
                    user.AttackController.ChangeAttackStyle(_originalAttackStyle);
                }
            }
        }
    }
}