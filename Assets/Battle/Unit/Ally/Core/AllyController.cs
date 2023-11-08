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
                    private UnitParameter _param = default;
                    [SerializeField]
                    private string _name;
                    [SerializeField]
                    private AllyLifeController _lifeController;
                    [SerializeField]
                    private AllyAttackController _attackController;

                    public UnitParameter Param => _param;
                    public string Name => _name;
                    public Vector3 WorldPosition => transform.position;
                    public AllyLifeController LifeController => _lifeController;
                    public AllyAttackController AttackController => _attackController;

                    public event Action<IDamageable> OnDead;

                    private void Start()
                    {
                        _lifeController.Initialize(this);
                        _attackController.Initialize(this);
                    }

                    private void Update()
                    {
                        _attackController.Update();
                    }

                    private void OnDestroy()
                    {
                        OnDead?.Invoke(this);
                    }

                    public void Damge(float value)
                    {
                        _lifeController.Damge(value);
                    }
                }
            }
        }
    }
}