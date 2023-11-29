// 日本語対応
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public class AutoModeSwitchButton : MonoBehaviour
        {
            [SerializeField]
            private Button _autoModeButton;

            private void Start()
            {
                _autoModeButton.onClick.AddListener(SwitchAutoMode);
            }

            private void SwitchAutoMode()
            {
                // オートモードボタンが押されたとき
                // オートモードであればオートモードを解除する。
                // そうでなければ、オートモードにする。
                if (AutoModeManager.Instance.IsAutoMode) AutoModeManager.Instance.StopAutoMode();
                else AutoModeManager.Instance.StartAutoMode();
            }
        }
    }
}