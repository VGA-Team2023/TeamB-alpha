using UnityEngine;
using UnityEngine.UI;
using System;

namespace TeamB_TD
{
    namespace Battle
    {
        public class GameSpeedChangeButton : MonoBehaviour
        {
            [SerializeField]
            private Button _button;
            [SerializeField]
            private Image _myImage;
            [SerializeField]
            private Sprite _speedx1Sprite;
            [SerializeField]
            private Sprite _speedx2Sprite;
            [SerializeField]
            private Sprite _speedx3Sprite;

            private void Start()
            {
                _button.onClick.AddListener(OnClicked);
                UpdateImage(GameSpeedController.CurrentSpeed);
            }

            private void OnClicked()
            {
                UpdateSpeed(GameSpeedController.CurrentSpeed);
                UpdateImage(GameSpeedController.CurrentSpeed);
            }

            private void UpdateSpeed(float gameSpeed)
            {
                if (Mathf.Approximately(gameSpeed, 1f))
                {
                    GameSpeedController.ChangeGameSpeed(2f);
                }
                else if (Mathf.Approximately(gameSpeed, 2f))
                {
                    GameSpeedController.ChangeGameSpeed(3f);
                }
                else if (Mathf.Approximately(gameSpeed, 3f))
                {
                    GameSpeedController.ChangeGameSpeed(1f);
                }
                else
                {
                    throw new ArithmeticException($"想定外の値です。{nameof(gameSpeed)}");
                }
            }

            private void UpdateImage(float gameSpeed)
            {
                if (Mathf.Approximately(gameSpeed, 1f))
                {
                    _myImage.sprite = _speedx1Sprite;
                }
                else if (Mathf.Approximately(gameSpeed, 2f))
                {
                    _myImage.sprite = _speedx2Sprite;
                }
                else if (Mathf.Approximately(gameSpeed, 3f))
                {
                    _myImage.sprite = _speedx3Sprite;
                }
                else
                {
                    throw new ArithmeticException($"想定外の値です。{nameof(gameSpeed)}");
                }
            }
        }
    }
}