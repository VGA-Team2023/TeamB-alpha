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
                public class EnemyLifeController
                {
                    [SerializeField, Range(1f, 100f)]
                    private float _maxLife;
                    [SerializeField]
                    private float _currentLife;

                    private EnemyController _controller;

                    public float MaxLife => _maxLife;
                    public float CurrentLife => _currentLife;

                    public event Action<float> OnLifeChanged;
                    public event Action OnDead;

                    public void Initialize(EnemyController enemyController)
                    {
                        _controller = enemyController;
                        _currentLife = _maxLife;
                    }

                    public void Damage(float value)
                    {
                        var old = _currentLife;
                        _currentLife -= value;
                        if (old != _currentLife) OnLifeChanged?.Invoke(_currentLife);

                        if (old > 0 && _currentLife <= 0)
                        {
                            EnemyCounter.Current.OnEnemyDead();
                            OnDead?.Invoke();

                            GameObject.Destroy(_controller.gameObject);
                        }
                    }
                }
            }
        }
    }
}