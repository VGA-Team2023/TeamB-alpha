using System.Collections;
using TeamB_TD.Battle.Unit.Enemy;
using TeamB_TD.Tower;
using TeamB_TD.UI;
using UnityEngine;

namespace TeamB_TD
{
    namespace Result
    {
        public class GameResultController : MonoBehaviour
        {
            [SerializeField] GameResultViewer _gameResultViewer;
            [SerializeField] TowerController _towerController;

            public void GameClearResultSet()
            {
                _gameResultViewer.TowerHPSet(_towerController.Life);
                _gameResultViewer.GameClearPanelChangeActive(true);
            }

            public void GameOverResultSet()
            {
                _gameResultViewer.GameOverPanelChangeActive(true);
            }
        }
    }
}


