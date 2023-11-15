using System.Collections;
using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Enemy;
using TeamB_TD.Tower;
using UnityEngine;

namespace TeamB_TD
{
    namespace Result
    {
        public class GameResultController : MonoBehaviour
        {
            [SerializeField] GameResultViewer _gameResultViewer;
            [SerializeField] TowerController _towerController;

            public void ResultScoreSet()
            {
                EnableResultPanel();
                _gameResultViewer.DeadEnemyCountSet(EnemyCounter.Current.DeadEnemyCount);
                _gameResultViewer.TowerHPSet(_towerController.Life);
            }

            public void EnableResultPanel()
            {
                this.gameObject.SetActive(true);
            }

            public void DisableResultPanel()
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}


