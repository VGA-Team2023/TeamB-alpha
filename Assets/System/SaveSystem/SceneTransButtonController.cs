using UnityEngine;
using UnityEngine.EventSystems;
using TeamB_TD.UI;

namespace TeamB_TD
{ 
    namespace SaveData
    {
        public class SceneTransButtonController : MonoBehaviour, IPointerClickHandler
        {
            [SerializeField] SceneName _nextScene;

            bool _isActive = true;
            public bool Active { set { _isActive = value; } }

            public void OnPointerClick(PointerEventData pointerEventData)
            {
                if (_isActive)
                {
                    SceneTransition.instance.SceneTrans(_nextScene.ToString());
                }
            }
            public void BeUntouchable()
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        public enum SceneName
        {
            TitleScene,
            StageSelect,
            Tutrial,
            Stage1,
            Stage2,
            Stage3,
        }
    }
}

