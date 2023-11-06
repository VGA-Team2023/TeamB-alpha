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
                public class AllySingleAttack : IAllyAttack
                {
                    [SerializeField]
                    private SingleObjectInTriggerFinder2D _colliderTriggerHandler;

                    public bool IsAnyObjectInTrigger()
                    {
                        var enemy = _colliderTriggerHandler.GetFirstEnteredObject<EnemyController>();
                        return enemy != null;
                    }

                    public void Fire(float attackPower)
                    {
                        var enemy = _colliderTriggerHandler.GetFirstEnteredObject<EnemyController>();
                        if (enemy == null) return;
                        enemy.Damge(attackPower);
                    }
                }
            }
        }
    }
}