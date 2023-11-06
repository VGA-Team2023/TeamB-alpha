// 日本語対応
using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                [Serializable]
                public struct AllyStatus
                {
                    public AllyStatus(int cost, float maxLife, float currentLife, float attackPower, float attackInterval, float attackIntervalTimer)
                    {
                        _cost = cost;
                        _maxLife = maxLife;
                        _currentLife = currentLife;
                        _attackPower = attackPower;
                        _attackInterval = attackInterval;
                        _attackIntervalTimer = attackIntervalTimer;
                    }

                    [SerializeField]
                    private int _cost;
                    [SerializeField]
                    private float _maxLife;
                    [SerializeField]
                    private float _attackPower;
                    [SerializeField]
                    private float _attackInterval;

                    [SerializeField] // インスペクタで監視する用。
                    private float _currentLife;
                    [SerializeField] // インスペクタで監視する用。
                    private float _attackIntervalTimer;

                    public int Cost => _cost;
                    public float MaxLife => _maxLife;
                    public float CurrentLife => _currentLife;
                    public float AttackPower => _attackPower;
                    public float AttackInterval => _attackInterval;
                    public float AttackIntervalTimer => _attackIntervalTimer;

                    public bool IsAttackable => _attackIntervalTimer <= 0f;
                    public bool IsDead => _currentLife <= 0f;

                    public void Update(float deltaTime)
                    {
                        _attackIntervalTimer -= deltaTime;
                        if (_attackIntervalTimer < 0f) _attackIntervalTimer = 0f;
                    }

                    // ISearchTargetがないので一時的にコメントアウト
                    //public void Attack(IReadOnlyList<ISearchTarget> targets)
                    //{
                    //    _attackIntervalTimer = _attackInterval;

                    //    foreach (var target in targets)
                    //    {
                    //        target.GetDamageable().Damage(_attackPower);
                    //    }
                    //}

                    public void Damage(float value)
                    {
                        _currentLife -= value;

                        if (_currentLife < 0) _currentLife = 0;
                    }

                    public void Heal(float value)
                    {
                        _currentLife += value;

                        if (_currentLife > _maxLife) _currentLife = _maxLife;
                    }

                    public void Initialize()
                    {
                        _currentLife = _maxLife;
                        _attackIntervalTimer = _attackInterval;
                    }
                }
            }
        }
    }
}