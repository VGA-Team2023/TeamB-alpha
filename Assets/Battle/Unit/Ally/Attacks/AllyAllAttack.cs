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
                public class AllyAllAttack : IAllyAttack
                {
                    [SerializeField]
                    private MultiObjectsInTriggerFinder2D _multiObjectInTriggerFinder;

                    public float AttackAnimationTime => 1.5f;

                    public bool IsAnyObjectInTrigger()
                    {
                        var enemies = _multiObjectInTriggerFinder.GetAllObjectsInTrigger<EnemyController>();
                        return enemies != null && enemies.Count > 0;
                    }

                    public void Fire(float attackPower)
                    {
                        var enemies = _multiObjectInTriggerFinder.GetAllObjectsInTrigger<EnemyController>();
                        foreach (var enemy in enemies)
                        {
                            enemy.Damge(attackPower);
                        }
                    }
                }
            }
        }
    }
}