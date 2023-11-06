using UnityEngine;
using UnityEngine.UI;

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
                UpdateText(GameSpeedController.CurretGameSpeed);
            }

            private void OnClicked()
            {
                UpdateSpeed(GameSpeedController.CurretGameSpeed);
                UpdateText(GameSpeedController.CurretGameSpeed);
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
                    GameSpeedController.ChangeGameSpeed(0f);
                }
                else if (Mathf.Approximately(gameSpeed, 0f))
                {
                    GameSpeedController.ChangeGameSpeed(1f);
                }
            }

            private void UpdateText(float gameSpeed)
            {
                if (Mathf.Approximately(gameSpeed, 0f))
                {
                    _text.text = "・";
                }
                else if (Mathf.Approximately(gameSpeed, 1f))
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
            }
        }
    }
}