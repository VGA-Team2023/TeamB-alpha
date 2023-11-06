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
                    [SerializeField, Range(0.1f, 100f)]
                    private float _attackPower;
                    [SerializeField, Range(0.1f, 8f)]
                    private float _attackInterval;
                    [SerializeReference, SubclassSelector]
                    private IAllyAttack _allyAttack;

                    private float _attackIntervalTimer = 0f;

                    // トリガー内にオブジェクトが存在し、
                    // 攻撃インターバルが経過していたら攻撃可能を表現する。
                    public bool IsAttackable =>
                        _attackIntervalTimer >= _attackInterval &&
                        _allyAttack.IsAnyObjectInTrigger();

                    public void Update()
                    {
                        if (_attackIntervalTimer < _attackInterval)
                        {
                            _attackIntervalTimer += Time.deltaTime;
                        }

                        if (IsAttackable)
                        {
                            _allyAttack.Fire(_attackPower);
                            _attackIntervalTimer = 0f;
                        }
                    }
                }
            }
        }
    }
}