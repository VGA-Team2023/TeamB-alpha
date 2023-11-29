using System;
using TeamB_TD.Battle.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class EnemyController : MonoBehaviour, IDamageable
                {
                    [SerializeField]
                    private EnemyParameter _param;
                    [SerializeField]
                    private string _name;
                    [SerializeField]
                    private EnemyAttackController _attackController;
                    [SerializeField]
                    private EnemyLifeController _lifeController;
                    [SerializeField]
                    private EnemyMove _moveController;

                    public EnemyParameter Param => _param;
                    public string Name => _name;
                    public EnemyAttackController AttackController => _attackController;
                    public EnemyLifeController LifeController => _lifeController;
                    public EnemyMove MoveController => _moveController;

                    public Vector3 WorldPosition => transform.position;

                    public event Action<IDamageable> OnDead;

                    public event Action<float> OnLifeChanged
                    {
                        add => _lifeController.OnLifeChanged += value;
                        remove => _lifeController.OnLifeChanged -= value;
                    }

                    public void Initialize(Stage stage, StageCell spawnerCell, StageCell goalCell)
                    {
                        _attackController.Initialize(this);
                        _lifeController.Initialize(this);
                        _moveController.Initialize(this, stage, spawnerCell, goalCell);
                    }

                    public void Update()
                    {
                        _attackController.Update();
                        _moveController.Update(transform);
                    }

                    private void OnDestroy()
                    {
                        OnDead?.Invoke(this);
                    }

                    public void Damge(float value)
                    {
                        CriAudioManager.Instance.BGM.Play("SE", "SE_003_battleUnit4");
                        _lifeController.Damage(value);

                        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
                        VFXManager.Current.RequestDamageVFX(value, screenPos);
                    }
                }
            }
        }
    }
}