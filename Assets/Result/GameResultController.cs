using System.Collections;
using TeamB_TD.Battle.Unit.Enemy;
using TeamB_TD.Battle.Tower;
using TeamB_TD.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

namespace TeamB_TD
{
    namespace Result
    {
        public class GameResultController : MonoBehaviour
        {
            [SerializeField] GameResultViewer _gameResultViewer;
            [SerializeField] GameClearAnimation _gameClearAnimation;
            //[SerializeField] TowerController _towerController;

            //test用
            private void Start()
            {
                StartCoroutine(GameClearResultSet());
            }

            public IEnumerator GameClearResultSet()
            {
                //_gameResultViewer.TowerHPSet(_towerController.Life);
                _gameResultViewer.GameClearPanelChangeActive(true);
                yield return _gameClearAnimation.GameClearTextAnimation();
                _gameResultViewer.GameClearPanelChangeActive(false);
                _gameResultViewer.ScorePanelChangeActive(true);
                StartCoroutine(_gameResultViewer.ScorePanelSet());
                yield return _gameClearAnimation.StarImageAnimationStart();
            }

            public void GameOverResultSet()
            {
                _gameResultViewer.GameOverPanelChangeActive(true);
            }
        }
    }
}


