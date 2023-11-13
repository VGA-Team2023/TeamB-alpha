using Glib.InspectorExtension;
using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                [Serializable]
                public class EnemyAttackController
                {
                    [SerializeReference, SubclassSelector]
                    private IEnemyAttack _attack;

                    private EnemyController _controller;

                    private float _attackIntervalTimer = 0f;

                    // トリガー内にオブジェクトが存在し、
                    // 攻撃インターバルが経過していたら攻撃可能を表現する。
                    public bool IsAttackable =>
                        _attackIntervalTimer >= _controller.Param.AttackInterval &&
                        _attack.IsAnyObjectInTrigger();

                    public void Initialize(EnemyController controller)
                    {
                        _controller = controller;
                    }
                    public void Update()
                    {
                        if (_attack == null) return;
                        if (_attackIntervalTimer < _controller.Param.AttackInterval)
                        {
                            var gameSpeed = GameSpeedController.CurretGameSpeed;
                            _attackIntervalTimer += Time.deltaTime * gameSpeed;
                        }

                        if (IsAttackable)
                        {
                            _attack.Fire(_controller.Param.AttackPower);
                            _attackIntervalTimer = 0f;
                        }
                    }
                }
            }
        }
    }
}