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
            private Sprite _pauseSprite;
            [SerializeField]
            private Sprite _resumeSprite;
            [SerializeField]
            private Image _pausePanel;

            private Image _myImage;

            private void Start()
            {
                _button.onClick.AddListener(OnButtonClicked);
                SetActiveController(GameSpeedController.IsPaused);
                ApplyImage();
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
                ApplyImage();
            }

            private void Pause()
            {
                GameSpeedController.Pause();
            }

            private void Resume()
            {
                GameSpeedController.Resume();
            }

            private void ApplyImage()
            {
                if (_myImage == null && TryGetComponent(out Image image)) _myImage = image;

                _myImage.sprite = GameSpeedController.IsPaused ? _pauseSprite : _resumeSprite;
            }

            private void SetActiveController(bool activeFrag)
            {
                _pausePanel?.gameObject.SetActive(activeFrag);
            }
        }
    }
}