using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

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
                [SerializeField]
                private float _duration = 0.4f;

                private TweenerCore<float, float, FloatOptions> _animation;

                private void Start()
                {
                    _slider.maxValue = _resourceManager.MaxResource;
                    _slider.minValue = 0f;

                    ApplyValue(_resourceManager.CurrentResource);

                    _resourceManager.OnResourceChanged += Animation;
                }

                private void ApplyValue(float value)
                {
                    _slider.value = value;
                }

                private void Animation(float endValue)
                {
                    _animation?.Kill();

                    _animation = DOTween.To(
                        () => _slider.value,
                        x => _slider.value = x,
                        endValue,
                        _duration);
                }

                private void OnDestroy()
                {
                    _animation?.Kill();
                }
            }
        }
    }
}