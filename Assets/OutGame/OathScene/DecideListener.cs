using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TeamB_TD.UI;
using TeamB_TD.SaveData;
using Glib.InspectorExtension;
namespace TeamB_TD
{
    namespace OutGame
    {
        public class DecideListener: MonoBehaviour
        {
            [SerializeField] 
            private GameObject _imgCanvas;
            [SerializeField]
            private int _characterNum = 6;
            [SerializeField]
            private Sprite[] _charImgArray;
            [SerializeField, SceneName] 
            private string _nextScene;

            private int _currentNum = 0;
            private int _memoryNum = 0;
            private bool _isChanged = false;
            public int GetNumber => _currentNum;

            SaveData.SaveData _instantdData; 
            
            private void Awake()
            {
                _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
                _instantdData = DataManager.Instance.Load();
            }
            private void Start()
            {
                _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
            }
            private void Update()
            {
                if (_currentNum != _memoryNum) _isChanged = true;
                if(_isChanged)
                {
                    _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
                    //CriAudioManager.Instance.BGM.Play(",", 2f);
                }
                
                _memoryNum = _currentNum;
            }
            public void FavCharDecide()
            {
                _instantdData._favoriteUnitId = _currentNum + 1;
                _instantdData._isClear[0] = true;
                DataManager.Instance.Save(_instantdData);
                //Debug.Log("上書きは正常に動作しています");
                SceneTransition.instance.SceneTrans(_nextScene);
            }

            public void SlideRight()
            {
                _currentNum++;
                _currentNum %= _characterNum;
                //Debug.Log($"currentNum：{_currentNum}");
            }
            public void SlideLeft()
            {
                _currentNum--;
                if(_currentNum < 0) _currentNum += _characterNum;
                //Debug.Log($"currentNum：{_currentNum}");
            }
        }
    }
}