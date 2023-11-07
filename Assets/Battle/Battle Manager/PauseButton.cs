using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        public class PauseButton : MonoBehaviour
        {
            [SerializeField]
            private Button _button;
            [SerializeField]
            private Text _text;

            private void Start()
            {
                _button.onClick.AddListener(OnButtonClicked);
                ApplyText();
            }

            private void OnButtonClicked()
            {
                if (GameSpeedController.IsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }

                ApplyText();
            }

            private void Pause()
            {
                GameSpeedController.Pause();
            }

            private void Resume()
            {
                GameSpeedController.Resume();
            }

            private void ApplyText()
            {
                if (GameSpeedController.IsPaused)
                {
                    _text.text = "||";
                }
                else
                {
                    _text.text = "▶";
                }
            }
        }
    }
}