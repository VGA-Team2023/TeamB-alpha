using TeamB_TD.Battle.Unit.Enemy;
using TeamB_TD.Battle.Tower;
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
            private string _enemyUiText = "敵";
            [SerializeField]
            private Text _towerLifeText = null;
            [SerializeField]
            private string _towerHealthText = "塔";

            private int _totalEnemyCount = -1;

            private void OnEnable()
            {
                var enemyCounter = EnemyCounter.Current;
                if (enemyCounter) enemyCounter.OnDeadEnemyCountChanged += ApplyDeadEnemyCount;

                var tower = TowerController.Instance;
                if (tower) tower.OnLifeChanged += ApplyTowerLife;
            }

            private void Start()
            {
                _totalEnemyCount = EnemyCounter.Current.TotalEnemyCount;
                ApplyDeadEnemyCount(EnemyCounter.Current.DeadEnemyCount);
                ApplyTowerLife(TowerController.Instance.CurrentLife);
            }

            private void OnDisable()
            {
                var enemyCounter = EnemyCounter.Current;
                if (enemyCounter) enemyCounter.OnDeadEnemyCountChanged -= ApplyDeadEnemyCount;

                var tower = TowerController.Instance;
                if (tower) tower.OnLifeChanged -= ApplyTowerLife;
            }

            private void ApplyDeadEnemyCount(int count)
            {
                _enemyCountText.text = $"{_enemyUiText}：{count} / {_totalEnemyCount}";
            }

            private void ApplyTowerLife(int life)
            {
                _towerLifeText.text = $"{_towerHealthText}：{life}";
            }
        }
    }
}
