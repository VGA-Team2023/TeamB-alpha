using System.Collections;
using TeamB_TD.Battle.Unit.Enemy;
using TeamB_TD.Battle.Tower;
using TeamB_TD.UI;
using TeamB_TD.SaveData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamB_TD
{
    namespace Result
    {
        public class GameResultController : MonoBehaviour
        {
            [SerializeField] int _stageNum = 0;
            [SerializeField] GameResultViewer _gameResultViewer;
            [SerializeField] GameClearAnimation _gameClearAnimation;
            [SerializeField] TowerController _towerController;

            public GameResultViewer GameResultViewer => _gameResultViewer;

            private void Start()
            {
                //テスト用
                StartCoroutine(GameClearResultSet());
            }

            public IEnumerator GameClearResultSet()
            {
                //_gameResultViewer.TowerHPSet(_towerController.CurrentLife);
                _gameResultViewer.GameClearPanelChangeActive(true);
                yield return _gameClearAnimation.GameClearTextAnimation();
                //_gameResultViewer.GameClearPanelChangeActive(false);
                _gameResultViewer.ScorePanelChangeActive(true);
                StartCoroutine(_gameResultViewer.ScorePanelSet());
                yield return _gameClearAnimation.
                    StarImageAnimationStart(StarCountCalculation(_towerController.CurrentLife));
                yield return _gameClearAnimation.
                    CharaImageAnimation(_gameResultViewer.CharaImage, _gameResultViewer.DispImgPos);
                _gameResultViewer.ResultClickPanelChangeActive(true);

                SaveData.SaveData instantData = DataManager.Instance.Load();
                instantData._isClear[_stageNum] = true;
                DataManager.Instance.Save(instantData);
            }

            private int StarCountCalculation(int current)
            {
                return current;
            }

            public void GameOverResultSet()
            {
                _gameResultViewer.GameOverPanelChangeActive(true);
            }

            public void TransitionButton()
            {
                SceneTransition.instance.SceneTrans("Scenario 1");
            }
        }
    }
}


