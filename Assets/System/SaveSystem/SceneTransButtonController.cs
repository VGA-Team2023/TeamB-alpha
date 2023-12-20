﻿using UnityEngine;
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
            bool _sceneDivergence = false;

            public string NextScene
            {
                get { return _nextScene; }
                set { _nextScene = value; }
            }

            bool _isActive = true;
            public bool Active { set { _isActive = value; } }

            public void OnPointerClick(PointerEventData pointerEventData)
            {
                //Debug.Log($"クリックは正常に動作しています：{this.gameObject.name}");
                if (_isActive)
                {
                    if (_sceneDivergence)
                    {
                        if (DataManager.Instance.PlayerData._favoriteUnitId != 0)
                        {
                            SceneTransition.instance.SceneTrans(_anotherNextScene);
                            return;
                        }                        
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

