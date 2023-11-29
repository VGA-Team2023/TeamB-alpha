using UnityEngine;
using System;
using System.Collections;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace ResourceManagement
        {
            public class ResourceManager : MonoBehaviour
            {
                [SerializeField]
                private BattleManager _battleManager;
                [SerializeField, Range(10f, 1000f)]
                private float _maxResource = 100f;
                [SerializeField, Range(10f, 1000f)]
                private float _initialResource = 0f;
                [SerializeField, Range(0.5f, 10f)]
                private float _addResourceSpeed = 1f;
                private float _currentResource = 0f;

                [Tooltip("リソースクールタイム用の変数、一定値超えたら0に戻す")]
                private float _forResourceCoolTimeNum = 0f;
                [SerializeField]
                private float _chargeCoolTime;
                private bool _chargeStart = true;
                
                public float MaxResource => _maxResource;
                public float CurrentResource => _currentResource;

                public event Action<float> OnResourceChanged;

                private void Start()
                {
                    _currentResource = _initialResource;
                    OnResourceChanged?.Invoke(_currentResource);
                }

                private void Update()
                {
                    var gameSpeed = GameSpeedController.CurretGameSpeed;
                    if (_chargeStart && _battleManager.Status != BattleManager.BattleStatus.GameOver
                                     && _battleManager.Status != BattleManager.BattleStatus.GameClear)
                    {
                        AddResource(Time.deltaTime * _addResourceSpeed * gameSpeed);
                        ResourceChargeMonitor();
                    }
                }

                public void AddResource(float resource)
                {
                    var old = _currentResource;
                    _currentResource += resource;

                    if (_currentResource > _maxResource)
                    {
                        _currentResource = _maxResource;
                    }

                    if (_currentResource != old)
                    {
                        OnResourceChanged?.Invoke(_currentResource);
                    }
                }

                public bool TryUseResource(float cost)
                {
                    if (_currentResource - cost >= 0)
                    {
                        _currentResource -= cost;
                        OnResourceChanged?.Invoke(_currentResource);
                        return true;
                    }
                    return false;
                }

                private void ResourceChargeMonitor()
                {
                    var gameSpeed = GameSpeedController.CurretGameSpeed;
                    _forResourceCoolTimeNum += Time.deltaTime * _addResourceSpeed * gameSpeed;
                    if(_forResourceCoolTimeNum >= 1f)
                    {
                        _forResourceCoolTimeNum = 0f;
                        _currentResource -= _currentResource % 1;
                        StartCoroutine(ChargeCoolTime());
                    }
                }

                private IEnumerator ChargeCoolTime()
                {
                    _chargeStart = false;
                    yield return new WaitForSeconds(_chargeCoolTime);
                    _chargeStart = true;
                }
            }
        }
    }
}