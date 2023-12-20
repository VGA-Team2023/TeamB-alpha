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
            [HideInInspector] public SaveData.SaveData _pData;

            [SerializeField] 
            GameObject _imgCanvas;
            [SerializeField]
            int _characterNum = 6;
            [SerializeField]
            Sprite[] _charImgArray;
            [SerializeField, SceneName] 
            private string _nextScene;

            string _filepath;            
            int _currentNum = 0;
            public int GetNumber => _currentNum;

            public static string _json;

            SaveData.SaveData memory;

            public SaveData.SaveData PlayerData => _pData;            
            
            private void Awake()
            {
                _filepath = Application.streamingAssetsPath + "/SaveData/SaveData.json";
                _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
                memory = DataManager.Instance.Load();
            }
            private void Start()
            {
                _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
            }
            private void Update()
            {
                _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
            }
            public void FavCharDecide()
            {
                memory._favoriteUnitId = _currentNum + 1;
                memory._isClear[0] = true;
                DataManager.Instance.Save(memory);
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