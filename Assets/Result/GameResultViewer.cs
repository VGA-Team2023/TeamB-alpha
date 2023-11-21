using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
        }
    }
}


 