using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class EnemyAllAttack : IEnemyAttack
                {
                    [SerializeField]
                    private MultiObjectsInTriggerFinder2D _multiObjectInTriggerFinder;

                    public bool IsAnyObjectInTrigger()
                    {
                        var allies = _multiObjectInTriggerFinder.GetAllObjectsInTrigger<IAllyDamageable>();
                        return allies != null && allies.Count > 0;
                    }

                    public void Fire(float attackPower)
                    {
                        var allies = _multiObjectInTriggerFinder.GetAllObjectsInTrigger<IAllyDamageable>();
                        foreach (var ally in allies)
                        {
                            ally.Damge(attackPower);
                        }
                    }
                }
            }
        }
    }
}