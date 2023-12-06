using System.IO;
using UnityEngine;
using UnityEngine.UI;
namespace TeamB_TD
{
    namespace OutGame
    {
        public class DecideListener: MonoBehaviour
        {
            [HideInInspector] public SaveData.SaveData _pData;

            [SerializeField] GameObject _imgCanvas;
            [SerializeField] int _characterNum = 6;
            [SerializeField] Sprite[] _charImgArray;
            
            string _filepath;            
            int _currentNum = 0;
            public int GetNumber => _currentNum;

            public static string _json;

            Sprite _dispImg;


            public SaveData.SaveData PlayerData => _pData;            
            
            private void Awake()
            {
                _filepath = Application.streamingAssetsPath + "/SaveData/SaveData.json";
                _imgCanvas.gameObject.GetComponent<Image>().sprite = _charImgArray[_currentNum];
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
                StreamReader rd = new StreamReader(_filepath);
                _json = rd.ReadToEnd();
                rd.Close();
                SaveData.SaveData memory = JsonUtility.FromJson<SaveData.SaveData>(_json);
                memory._favoriteUnitId = _currentNum;
                _json = JsonUtility.ToJson(memory);
                StreamWriter wr = new StreamWriter(_filepath, false);
                wr.WriteLine(_json);
                wr.Close();
                Debug.Log("上書きは正常に動作しています");
            }

            public void SlideRight()
            {
                _currentNum++;
                _currentNum %= _characterNum;
                Debug.Log($"currentNum：{_currentNum}");
            }
            public void SlideLeft()
            {
                _currentNum--;
                if(_currentNum < 0) _currentNum += _characterNum;
                Debug.Log($"currentNum：{_currentNum}");
            }
        }
    }
}