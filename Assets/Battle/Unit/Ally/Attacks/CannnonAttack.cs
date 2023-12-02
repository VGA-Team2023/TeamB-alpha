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
                public class CannnonAttack : IAllyAttack
                {
                    [SerializeField]
                    private Transform _userTransform;
                    [SerializeField]
                    private SingleObjectInTriggerFinder2D _fireTargetGetter;
                    [SerializeField]
                    private CannonBullet _bulletPrefab;

                    private float _multiplication = 1f;
                    public float AttackAnimationTime => 0.1f;

                    public void SetMultiplication(float value) { _multiplication = value; }

                    public void Fire(float attackPower)
                    {
                        var fireTarget = _fireTargetGetter.GetFirstEnteredObject<Enemy.EnemyController>();
                        FireBullet(fireTarget, attackPower * _multiplication);
                    }

                    public bool IsAnyObjectInTrigger()
                    {
                        return _fireTargetGetter.GetFirstEnteredObject<Enemy.EnemyController>() != null;
                    }

                    private void FireBullet(EnemyController enemy, float attackPower)
                    {
                        if (!_bulletPrefab)
                        {
                            Debug.Log("_bulletPrefab is not assigned");
                            return;
                        }
                        var instance = GameObject.Instantiate(_bulletPrefab, _userTransform.position, Quaternion.identity);
                        instance.Fire(enemy, 1f, attackPower);
                    }
                }
            }
        }
    }
}