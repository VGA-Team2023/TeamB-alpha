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
            [SerializeField]
            private Image _pausePanel;

            private void Start()
            {
                _button.onClick.AddListener(OnButtonClicked);
                SetActiveController(GameSpeedController.IsPaused);
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
                SetActiveController(GameSpeedController.IsPaused);
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

            private void SetActiveController(bool activeFrag)
            {
                _pausePanel?.gameObject.SetActive(activeFrag);
            }
        }
    }
}