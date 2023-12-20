using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TeamB_TD.SaveData;

namespace TeamB_TD
{
    namespace Result
    {
        public class GameResultViewer : MonoBehaviour
        {
            [SerializeField]
            private Text _towerHP;
            [SerializeField]
            private GameObject _gameoverPanel;
            [SerializeField] 
            private GameObject _gameclearPanel;
            [SerializeField]
            private GameObject _scorePanel;
            [SerializeField]
            private GameObject _scoreChildPanel;
            [SerializeField]
            private GameObject _resultClickPanel;
            [SerializeField]
            private Image _charaImage;
            public Image CharaImage => _charaImage;
            [SerializeField]
            private Sprite[] _charSpriteArray;

            [Header("キャラの立ち絵を表示したい座標")]
            [SerializeField] 
            private Vector2 _dispImgPos;
            public Vector2 DispImgPos => _dispImgPos;

            [Header("表示するキャラの立ち絵の大きさ")]

            [Header("横")]
            [SerializeField]
            private int _dispImgSizeWidth;
            [Header("縦")]
            [SerializeField]
            private int _dispImgSizeHeight;

            private void Awake()
            {
                _charaImage.GetComponent<RectTransform>().localPosition =
                                    new Vector2(_dispImgPos.x + 1000,_dispImgPos.y);
                Vector2 dispImgSize = new(_dispImgSizeWidth, _dispImgSizeHeight);
                _charaImage.GetComponent<RectTransform>().sizeDelta = dispImgSize;
            }
            private void Start()
            {
                //Vector3 defaultPos = _charaImage.GetComponent<RectTransform>().localPosition;
                //defaultPos.y = _dispImgPos.y;
                //_charaImage.GetComponent<RectTransform>().localPosition = defaultPos;
            }
            public void TowerHPSet(int value)
            {
                _towerHP.text = value.ToString();
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

            public void ResultClickPanelChangeActive(bool value)
            {
                _resultClickPanel.SetActive(value);
            }

            public IEnumerator ScorePanelSet()
            {
                SaveData.SaveData instantData = DataManager.Instance.Load();
                _charaImage.sprite = _charSpriteArray[instantData._favoriteUnitId - 1];
                _scoreChildPanel.SetActive(true);
                _scoreChildPanel.transform.DOScale(new Vector3(0.5f, 0.6f, 1), 1f);
                yield return new WaitForSeconds(1f);
                //_charaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-285f, 0), 0.5f);
                _charaImage.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-215f, -235f), 0.5f);
            }
        }
    }
}


 