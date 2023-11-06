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
                public class AllyLifeController
                {
                    [SerializeField]
                    private float _maxLife;

                    private float _currentLife;

                    public event Action OnDead;
                    public event Action<float, float> OnHealed;
                    public event Action<float, float> OnDamaged;

                    public void Heal(float value)
                    {
                        var old = _currentLife;
                        _currentLife += value;
                        if (_currentLife < 0) _currentLife = 0;

                        if (old < _currentLife)
                        {
                            OnHealed?.Invoke(old, _currentLife);
                        }
                        else if (old > _currentLife)
                        {
                            OnDamaged?.Invoke(old, _currentLife);
                        }

                        if (old > 0 && _currentLife <= 0)
                        {
                            OnDead?.Invoke();
                        }
                    }

                    public void Damge(float value)
                    {
                        var old = _currentLife;
                        _currentLife -= value;
                        if (_currentLife < 0) _currentLife = 0;

                        if (old < _currentLife)
                        {
                            OnHealed?.Invoke(old, _currentLife);
                        }
                        else if (old > _currentLife)
                        {
                            OnDamaged?.Invoke(old, _currentLife);
                        }

                        if (old > 0 && _currentLife <= 0)
                        {
                            OnDead?.Invoke();
                        }
                    }
                }
            }
        }
    }
}