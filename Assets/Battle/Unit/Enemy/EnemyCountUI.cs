using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                [DefaultExecutionOrder(100)]
                public class EnemyCountUI : MonoBehaviour
                {
                    [SerializeField]
                    private Text _enemyCount;
                    [SerializeField]
                    private Text _deadEnemyCount;
                    [SerializeField]
                    private Text _towerInvasionCount;
                    [SerializeField]
                    private Text _completedEnemyCount;

                    private void Start()
                    {
                        var enemyCounter = EnemyCounter.Current;
                        ApplyEnemyCount(enemyCounter.EnemyCount);
                        ApplyDeadEnemyCount(enemyCounter.DeadEnemyCount);
                        ApplyTowerInvasionCount(enemyCounter.TowerInvasionCount);
                        ApplyCompletedEnemyCount(enemyCounter.CompletedEnemyCount);
                    }

                    private void OnEnable()
                    {
                        var enemyCounter = EnemyCounter.Current;
                        if (enemyCounter)
                        {
                            enemyCounter.OnDeadEnemyCountChanged += ApplyDeadEnemyCount;
                            enemyCounter.OnTowerInvasionCountChanged += ApplyTowerInvasionCount;
                            enemyCounter.OnCompletedEnemyCountChanged += ApplyCompletedEnemyCount;
                        }
                    }

                    private void OnDisable()
                    {
                        var enemyCounter = EnemyCounter.Current;
                        if (enemyCounter)
                        {
                            enemyCounter.OnDeadEnemyCountChanged -= ApplyDeadEnemyCount;
                            enemyCounter.OnTowerInvasionCountChanged -= ApplyTowerInvasionCount;
                            enemyCounter.OnCompletedEnemyCountChanged -= ApplyCompletedEnemyCount;
                        }
                    }

                    private void ApplyEnemyCount(int count)
                    {
                        _enemyCount.text = $"敵の全体数: {count}";
                    }
                    private void ApplyDeadEnemyCount(int count)
                    {
                        _deadEnemyCount.text = $"死んだ敵の数: {count}";
                    }
                    private void ApplyTowerInvasionCount(int count)
                    {
                        _towerInvasionCount.text = $"タワーに到着した敵の数: {count}";
                    }
                    private void ApplyCompletedEnemyCount(int count)
                    {
                        _completedEnemyCount.text = $"行動完了した敵の数: {count}";
                    }
                }
            }
        }
    }
}