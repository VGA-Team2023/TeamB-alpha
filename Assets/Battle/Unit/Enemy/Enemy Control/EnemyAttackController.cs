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
                    [SerializeField, Range(0.1f, 100f)]
                    private float _attackPower;
                    [SerializeField, Range(0.1f, 8f)]
                    private float _attackInterval;
                    [SerializeReference, SubclassSelector]
                    private IEnemyAttack _attack;

                    private float _attackIntervalTimer = 0f;

                    // トリガー内にオブジェクトが存在し、
                    // 攻撃インターバルが経過していたら攻撃可能を表現する。
                    public bool IsAttackable =>
                        _attackIntervalTimer >= _attackInterval &&
                        _attack.IsAnyObjectInTrigger();

                    public void Update()
                    {
                        if (_attack == null) return;
                        if (_attackIntervalTimer < _attackInterval)
                        {
                            var gameSpeed = GameSpeedController.CurretGameSpeed;
                            _attackIntervalTimer += Time.deltaTime * gameSpeed;
                        }

                        if (IsAttackable)
                        {
                            _attack.Fire(_attackPower);
                            _attackIntervalTimer = 0f;
                        }
                    }
                }
            }
        }
    }
}