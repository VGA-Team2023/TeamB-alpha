using Cysharp.Threading.Tasks;
using System;
using TeamB_TD.Battle.StageManagement;
using Unity.VisualScripting.Antlr3.Runtime;
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
                    [SerializeField]
                    private SpriteRenderer _spriteRenderer;
                    [SerializeField]
                    private float _fadeoutDuration = 1f;

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

                    public void Initialize(Stage stage, IStageCell spawnerCell, IStageCell goalCell)
                    {
                        _attackController.Initialize(this);
                        _lifeController.Initialize(this);
                        _moveController.Initialize(this, stage, spawnerCell, goalCell);
                    }

                    public void Update()
                    {
                        _attackController.Update();
                        _moveController.Update(transform, _moveSpeedDecelerationRate);
                    }

                    private void OnDestroy()
                    {
                        OnDead?.Invoke(this);
                    }

                    public void Damge(float value)
                    {
                        
                        _lifeController.Damage(value);

                        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
                        VFXManager.Current.RequestDamageVFX(value, screenPos);
                    }


                    private float _moveSpeedDecelerationRate = 1f;

                    public float MoveSpeedDecelerationRate => _moveSpeedDecelerationRate;

                    public void ChangeMoveSpeedDecelerationRate(float value)
                    {
                        _moveSpeedDecelerationRate = value;
                    }

                    public async UniTask PlayFadeOutAsync()
                    {
                        var startCol = _spriteRenderer.color;
                        var endCol = _spriteRenderer.color;
                        endCol.a = 0f;

                        for (var t = 0f; t < _fadeoutDuration; t += Time.deltaTime * GameSpeedController.CurretGameSpeed)
                        {
                            _spriteRenderer.color = Color.Lerp(startCol, endCol, t / _fadeoutDuration);
                            await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                        }

                        _spriteRenderer.color = endCol;
                    }
                }
            }
        }
    }
}