using UnityEngine;
using UnityEngine.SceneManagement;

namespace TeamB_TD
{
    namespace UI
    {
        public class SceneTransition : MonoBehaviour
        {
            [Header("次のシーンに移るまでの時間")]
            [SerializeField] private float _delayTime = 0f;

            public static SceneTransition instance;
            public void Awake()
            {
                if (instance == null)
                {
                    instance = this;
                    DontDestroyOnLoad(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            public void SceneTrans(string sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}


