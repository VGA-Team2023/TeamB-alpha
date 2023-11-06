using System;
using Glib.InspectorExtension;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyController : MonoBehaviour, IDamageable
                {
                    [SerializeField]
                    private string _name;
                    [SerializeField]
                    private AllyStatus _status;
                    [SerializeField]
                    private AllyLifeController _lifeController;
                    [SerializeField]
                    private AllyAttackController _attackController;

                    public string Name => _name;
                    public int Cost => _status.Cost;
                    public AllyStatus Status => _status;
                    public Vector3 WorldPosition => transform.position;

                    public event Action<IDamageable> OnDead;

                    private void Update()
                    {
                        _attackController.Update();
                    }

                    private void OnEnable()
                    {
                        if (_lifeController != null)
                            _lifeController.OnDead += Dead;
                    }

                    private void OnDisable()
                    {
                        if (_lifeController != null)
                            _lifeController.OnDead -= Dead;
                    }

                    public void Damge(float value)
                    {
                        _lifeController.Damge(value);
                    }

                    private void Dead()
                    {
                        OnDead(this);
                    }
                }
            }
        }
    }
}