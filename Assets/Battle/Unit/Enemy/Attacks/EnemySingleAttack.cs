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
                public class EnemySingleAttack : IEnemyAttack
                {
                    [SerializeField]
                    private SingleObjectInTriggerFinder2D _colliderTriggerHandler;

                    public bool IsAnyObjectInTrigger()
                    {
                        var ally = _colliderTriggerHandler.GetFirstEnteredObject<AllyController>();
                        return ally != null;
                    }

                    public void Fire(float attackPower)
                    {
                        var ally = _colliderTriggerHandler.GetFirstEnteredObject<AllyController>();
                        if (ally == null) return;
                        ally.Damge(attackPower);
                        // CriAudioManager.Instance.SE.Play("SE", "SE_004_enemy1", 0.5f);
                    }
                }
            }
        }
    }
}