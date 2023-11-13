using System;
using TeamB_TD.Battle.Craft;
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
                    [SerializeField]
                    private float _currentLife;
                    [SerializeField, Range(0.1f, 50f)]
                    private float _droppedResourceAmount = 0.2f; // このエネミー死亡時に加算するクラフトリソースの量。

                    private EnemyController _controller;

                    public float CurrentLife => _currentLife;

                    public event Action<float> OnLifeChanged;
                    public event Action OnDead;

                    public void Initialize(EnemyController enemyController)
                    {
                        _controller = enemyController;
                        _currentLife = _controller.Param.MaxHP;
                    }

                    public void Damage(float value)
                    {
                        var old = _currentLife;
                        _currentLife -= value;
                        if (old != _currentLife) OnLifeChanged?.Invoke(_currentLife);

                        if (old > 0 && _currentLife <= 0)
                        {
                            EnemyCounter.Current.OnEnemyDead();
                            CraftResourceManager.Current.AddResource(_droppedResourceAmount);

                            OnDead?.Invoke();

                            GameObject.Destroy(_controller.gameObject);
                        }
                    }
                }
            }
        }
    }
}