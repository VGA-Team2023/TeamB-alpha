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

            bool _isActive = true;
            public bool Active { set { _isActive = value; } }

            public void OnPointerClick(PointerEventData pointerEventData)
            {
                if (_isActive)
                {
                    SceneTransition.instance.SceneTrans(_nextScene);
                }
            }
            public void BeUntouchable()
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}

