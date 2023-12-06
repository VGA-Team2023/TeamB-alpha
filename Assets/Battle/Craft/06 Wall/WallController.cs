using System;
using TeamB_TD.Battle.Unit;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour, IAllyDamageable
{
    [SerializeField]
    private float _life;
    [SerializeField]
    private Slider _lifeSlider;

    public event Action<float> OnChangedDamage;

    public Vector3 WorldPosition => this.transform.position;
    public event Action<IDamageable> OnDead;

    public void Damge(float value)
    {
        _life -= value;
        OnChangedDamage?.Invoke(value);

        if (_life <= 0)
        {
            OnDead?.Invoke(this);
            Destroy(this.gameObject);
        }
    }

    public void Initialize(float initialLife)
    {
        _life = initialLife;

        _lifeSlider.minValue = 0f;
        _lifeSlider.maxValue = initialLife;
        _lifeSlider.value = initialLife;

        OnChangedDamage += UpdateLifeSliderView;
    }

    private void UpdateLifeSliderView(float value)
    {
        _lifeSlider.value = _life;
    }
}