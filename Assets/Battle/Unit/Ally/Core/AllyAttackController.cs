using Glib.InspectorExtension;
using UnityEngine;
using System;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                [Serializable]
                public class AllyAttackController
                {
                    [SerializeReference, SubclassSelector]
                    private IAllyAttack _allyAttack;

                    private AllyController _controller;

                    private float _attackIntervalTimer = 0f;

                    // トリガー内にオブジェクトが存在し、
                    // 攻撃インターバルが経過していたら攻撃可能を表現する。
                    public bool IsAttackable =>
                        _attackIntervalTimer >= _controller.Param.AttackInterval &&
                        _allyAttack != null &&
                        _allyAttack.IsAnyObjectInTrigger();

                    public void Initialize(AllyController controller)
                    {
                        _controller = controller;
                    }

                    public void Update()
                    {
                        if (_attackIntervalTimer < _controller.Param.AttackInterval)
                        {
                            var gameSpeed = GameSpeedController.CurretGameSpeed;
                            _attackIntervalTimer += Time.deltaTime * gameSpeed;
                        }

                        if (IsAttackable)
                        {
                            _allyAttack.Fire(_controller.Param.AttackPower);
                            _attackIntervalTimer = 0f;
                        }
                    }
                }
            }
        }
    }
}