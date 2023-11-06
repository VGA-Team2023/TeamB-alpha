namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public interface IEnemyAttack
                {
                    bool IsAnyObjectInTrigger();
                    void Fire(float attackPower);
                }
            }
        }
    }
}