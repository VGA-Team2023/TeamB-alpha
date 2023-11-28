using System.IO;
using UnityEngine;

namespace TeamB_TD
{
    namespace SaveData
    {
        public class StageSelectUIController : MonoBehaviour
        {
            [SerializeField] SceneTransButtonController[] _buttons;
            string _path;
            SaveData _pData;

            private void Start()
            {
                _path = Application.dataPath + "/SaveData/" + DataManager.GetPDataFileName();
                StreamReader rd = new StreamReader(_path);
                //string json = rd.ReadToEnd();
                string json = DataManager.GetPDataJson();
                //rd.Close();
                Debug.Log(json);
                _pData = JsonUtility.FromJson<SaveData>(json);
                for (int i = 0; i < _buttons.Length - 1; i++)
                {
                    if (!_pData._isClear[i])
                    {
                        _buttons[i + 1].Active = false;
                        _buttons[i + 1].BeUntouchable();
                    }
                }
            }
        }
    }
}

