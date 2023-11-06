﻿using System;
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
                    [SerializeField]
                    private float _currentLife;

                    private AllyController _controller;

                    public float MaxLife => _maxLife;
                    public float CurrentLife => _currentLife;

                    public event Action OnDead;
                    public event Action<float> OnLifeChanged;

                    public void Initialize(AllyController controller)
                    {
                        _controller = controller;
                        _currentLife = _maxLife;
                    }

                    public void Heal(float value)
                    {
                        var old = _currentLife;
                        _currentLife += value;
                        if (_currentLife > _maxLife) _currentLife = MaxLife;
                        if (_currentLife < 0) _currentLife = 0;

                        if (old != _currentLife)
                        {
                            OnLifeChanged(_currentLife);
                        }

                        if (old > 0 && _currentLife <= 0)
                        {
                            OnDead?.Invoke();
                            GameObject.Destroy(_controller.gameObject);
                        }
                    }

                    public void Damge(float value)
                    {
                        var old = _currentLife;
                        _currentLife -= value;
                        if (_currentLife > _maxLife) _currentLife = MaxLife;
                        if (_currentLife < 0) _currentLife = 0;

                        if (old != _currentLife)
                        {
                            OnLifeChanged(_currentLife);
                        }

                        if (old > 0 && _currentLife <= 0)
                        {
                            OnDead?.Invoke();
                            GameObject.Destroy(_controller.gameObject);
                        }
                    }
                }
            }
        }
    }
}