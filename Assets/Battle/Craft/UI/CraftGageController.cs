using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TeamB_TD.Battle.Craft;
using UnityEngine;
using UnityEngine.UI;

public class CraftGageController : MonoBehaviour
{
    [SerializeField]
    private CraftResourceManager _resourceManager;

    [SerializeField]
    private float _duration = 0.4f;
    [SerializeField]
    private Image _image;

    private float MaxResource => _resourceManager.MaxResource;
    private float Amount(float value) => value / MaxResource;

    private TweenerCore<float, float, FloatOptions> _animation;

    private void Start()
    {
        _image.fillAmount = Amount(_resourceManager.CurrentResource);
        _resourceManager.OnResourceChanged += Animation;
    }

    private void Animation(float value)
    {
        _animation?.Kill();

        _animation = DOTween.To(
            () => _image.fillAmount,
            x => _image.fillAmount = x,
            Amount(value),
            _duration);
    }

    private void OnDestroy()
    {
        _resourceManager.OnResourceChanged -= Animation;
        _animation?.Kill();
    }
}