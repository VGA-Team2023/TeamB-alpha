using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

namespace TeamB_TD
{
    namespace Result
    {
        public class GameResultViewer : MonoBehaviour
        {
            [SerializeField] private Text _towerHP;
            [SerializeField] private GameObject _gameoverPanel;
            [SerializeField] private GameObject _gameclearPanel;
            [SerializeField] private GameObject _scorePanel;
            [SerializeField] private GameObject _scoreChildPanel;
            [SerializeField] private Image _charaImage;

            public void TowerHPSet(int value)
            {
                _towerHP.text = $"タワーHP : {value}";
            }

            public void GameClearPanelChangeActive(bool value)
            {
                _gameclearPanel.SetActive(value);
            }

            public void GameOverPanelChangeActive(bool value)
            {
                _gameoverPanel.SetActive(value);
            }

            public void ScorePanelChangeActive(bool value)
            {
                _scorePanel.SetActive(value);
            }

            public IEnumerator ScorePanelSet()
            {
                _scoreChildPanel.SetActive(true);
                _scoreChildPanel.transform.DOScale(new Vector3(0.5f, 0.6f, 1), 1f);
                yield return new WaitForSeconds(1f);
                _charaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-285f, 0), 0.5f);
            }
        }
    }
}


 