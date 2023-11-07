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
            private Text _text;

            private void Start()
            {
                _button.onClick.AddListener(OnClicked);
                UpdateText(GameSpeedController.CurrentSpeed);
            }

            private void OnClicked()
            {
                UpdateSpeed(GameSpeedController.CurrentSpeed);
                UpdateText(GameSpeedController.CurrentSpeed);
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

            private void UpdateText(float gameSpeed)
            {
                if (Mathf.Approximately(gameSpeed, 1f))
                {
                    _text.text = ">";
                }
                else if (Mathf.Approximately(gameSpeed, 2f))
                {
                    _text.text = ">>";
                }
                else if (Mathf.Approximately(gameSpeed, 3f))
                {
                    _text.text = ">>>";
                }
                else
                {
                    throw new ArithmeticException($"想定外の値です。{nameof(gameSpeed)}");
                }
            }
        }
    }
}