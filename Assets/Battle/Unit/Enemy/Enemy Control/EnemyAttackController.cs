using System;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                [Serializable]
                public class EnemyAttackController
                {
                    private EnemyController _enemyController;

                    public void Initialize(EnemyController enemy)
                    {
                        _enemyController = enemy;
                    }

                    public void Update()
                    {

                    }
                }
            }
        }
    }
}