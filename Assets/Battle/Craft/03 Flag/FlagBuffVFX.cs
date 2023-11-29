using TeamB_TD.Battle;
using UnityEngine;

public class FlagBuffVFX : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    private float _timer = 0f;
    private float _lifeTime;

    public void Initialize(float lifetime)
    {
        _lifeTime = lifetime;
    }

    private void Update()
    {
        if (_timer <= _lifeTime)
        {
            _timer += Time.deltaTime * GameSpeedController.CurretGameSpeed;
            if (_timer > _lifeTime)
            {
                _particleSystem.Stop();
            }
        }
    }

    public void StopRequest()
    {
        try
        {
            _particleSystem.Stop();
        }
        catch (MissingReferenceException)
        {
            return;
        }
    }
}