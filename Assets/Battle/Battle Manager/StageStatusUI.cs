using TeamB_TD.Battle.Unit.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        [DefaultExecutionOrder(100)]  // EnemyCounterよりも実行順序が遅くないと、敵の全体数を取得してきたときに「0」になる。
        public class StageStatusUI : MonoBehaviour
        {
            [SerializeField]
            private Text _enemyCountText = null;
            [SerializeField]
            private Text _towerLifeText = null;

            private int _totalEnemyCount = -1;

            private void OnEnable()
            {
                var enemyCounter = EnemyCounter.Current;

                if (enemyCounter)
                {
                    enemyCounter.OnDeadEnemyCountChanged += ApplyDeadEnemyCount;
                }
            }

            private void Start()
            {
                _totalEnemyCount = EnemyCounter.Current.TotalEnemyCount;
                ApplyDeadEnemyCount(EnemyCounter.Current.DeadEnemyCount);
                ApplyTowerLife(-1);
            }

            private void OnDisable()
            {
                var enemyCounter = EnemyCounter.Current;

                if (enemyCounter)
                {
                    enemyCounter.OnDeadEnemyCountChanged -= ApplyDeadEnemyCount;
                }
            }

            private void ApplyDeadEnemyCount(int count)
            {
                _enemyCountText.text = $"敵：{count} / {_totalEnemyCount}";
            }

            private void ApplyTowerLife(int life)
            {
                _towerLifeText.text = /*$"塔：{life}"*/"塔：Value";
            }
        }
    }
}
