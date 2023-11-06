using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        public interface IAllyAttack
        {
            bool IsAnyObjectInTrigger();
            void Fire(float attackPower);
        }
    }
}