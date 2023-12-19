using System.IO;
using UnityEngine;
using TeamB_TD.SaveData;


namespace TeamB_TD
{
    namespace SaveData
    {
        public class StageSelectUIController : MonoBehaviour
        {
            [SerializeField] SceneTransButtonController[] _buttons;
            
            private void Start()
            {
                SaveData instantData = DataManager.Instance.Load();
                for (int i = 0; i < _buttons.Length - 1; i++)
                {
                    if (!instantData._isClear[i])
                    {
                        _buttons[i + 1].Active = false;
                        _buttons[i + 1].BeUntouchable();
                    }
                }                
            }
        }
    }
}

