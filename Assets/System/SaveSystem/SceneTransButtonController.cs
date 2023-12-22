using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TeamB_TD.UI;
using Glib.InspectorExtension;


namespace TeamB_TD
{ 
    namespace SaveData
    {
        public class SceneTransButtonController : MonoBehaviour, IPointerClickHandler
        {
            [SerializeField, SceneName]
            private string _nextScene;
            [SerializeField, SceneName]
            private string _anotherNextScene;
            [SerializeField]
            private bool _sceneDivergence = false;
            [SerializeField]
            private bool _transitionDelay = false;
            [SerializeField]
            private float _delayTime = 5f;
            [SerializeField]
            private bool _playSound = false;

            private int _myFavUnit = 0;
            private int _voiceNum = 0;
            public string NextScene
            {
                get { return _nextScene; }
                set { _nextScene = value; }
            }

            private bool _isActive = true;
            public bool Active { set { _isActive = value; } }

            SaveData instantData;

            private void Start()
            {
                instantData = DataManager.Instance.PlayerData;
                _myFavUnit = instantData._favoriteUnitId;
                if(_playSound)
                {
                    _voiceNum = Random.Range(1, 16);                    
                    if (_myFavUnit == 1 || _myFavUnit == 2 || _myFavUnit == 4)
                    {
                        _voiceNum %= 4;
                    }
                    else
                    {
                        _voiceNum %= 6;
                    }
                    Debug.Log($"Playing Sound is {_myFavUnit}_{_voiceNum}!");
                }
                
            }
            private void Update() 
            {
                if(instantData._favoriteUnitId == DataManager.Instance.PlayerData._favoriteUnitId)return;
                
                instantData._favoriteUnitId = DataManager.Instance.PlayerData._favoriteUnitId;
                Debug.Log($"{instantData._favoriteUnitId}");
            }
            
            public void OnPointerClick(PointerEventData pointerEventData)
            {
                //Debug.Log($"クリックは正常に動作しています：{this.gameObject.name}");
                if (_isActive)
                {
                    if (_sceneDivergence)
                    {
                        if (instantData._favoriteUnitId != 0)
                        {
                            SceneTransition.instance.SceneTrans(_anotherNextScene);
                            return;
                        }                        
                    }
                    
                    if(_playSound)
                    {
                        CriAudioManager.Instance.BGM.Play($"unit{_myFavUnit}", $"VOICE07_chapter{_myFavUnit}_{_voiceNum}", 1f);

                        if (_transitionDelay)
                        {
                            Debug.Log("コルーチンを含む関数が実行されています");
                            SceneTransition.instance.SceneTrans(_nextScene, _delayTime);
                            
                        }
                        else
                        {
                            Debug.Log("コルーチンを含まない関数が実行されています");
                            SceneTransition.instance.SceneTrans(_nextScene);
                        }
                        return;
                    }

                    SceneTransition.instance.SceneTrans(_nextScene);
                }
            }
            public void BeUntouchable()
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            }           

        }
    }
}

