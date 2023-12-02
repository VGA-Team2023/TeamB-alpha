using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class BombAttack : IAllyAttack
                {
                    [SerializeField]
                    private Transform _userTransform;
                    [SerializeField]
                    private SingleObjectInTriggerFinder2D _fireTargetGetter;
                    [SerializeField]
                    private BombController _bombPrefab;

                    private float _multiplication = 1f;
                    public float AttackAnimationTime => 0.1f;

                    public void SetMultiplication(float value) { _multiplication = value; }

                    public void Fire(float attackPower)
                    {
                        var fireTarget = _fireTargetGetter.GetFirstEnteredObject<Enemy.EnemyController>();
                        ThrowBomb(fireTarget, attackPower * _multiplication);
                    }

                    public bool IsAnyObjectInTrigger()
                    {
                        return _fireTargetGetter.GetFirstEnteredObject<Enemy.EnemyController>() != null;

                    }

                    private void ThrowBomb(EnemyController enemy, float attackPower)
                    {
                        if (!_bombPrefab)
                        {
                            Debug.Log("BombPrefab is not assigned");
                            return;
                        }
                        var instance = GameObject.Instantiate(_bombPrefab, _userTransform.position, Quaternion.identity);
                        instance.Throw(enemy, 1f, attackPower);
                    }
                }
            }
        }
    }
}