using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftResourceSlider : MonoBehaviour
            {
                [SerializeField]
                private CraftResourceManager _resourceManager;
                [SerializeField]
                private Slider _slider;

                private void Start()
                {
                    _slider.maxValue = _resourceManager.MaxResource;
                    _slider.minValue = 0f;

                    ApplyValue(_resourceManager.CurrentResource);

                    _resourceManager.OnResourceChanged += ApplyValue;
                }

                private void ApplyValue(float value)
                {
                    _slider.value = value;
                }
            }
        }
    }
}