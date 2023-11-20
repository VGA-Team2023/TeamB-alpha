using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        public interface IAllyAttack
        {
            float AttackAnimationTime { get; }
            bool IsAnyObjectInTrigger();
            void Fire(float attackPower);
        }
    }
}