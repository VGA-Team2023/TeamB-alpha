using UnityEngine;
using System;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace ResourceManagement
        {
            public class ResourceManager : MonoBehaviour
            {
                [SerializeField, Range(10f, 1000f)]
                private float _maxResource = 100f;
                [SerializeField, Range(10f, 1000f)]
                private float _initialResource = 0f;
                [SerializeField, Range(0.5f, 10f)]
                private float _addResourceSpeed = 1f;

                private float _currentResource = 0f;

                public float MaxResource => _maxResource;
                public float CurrentResource => _currentResource;

                public event Action<float> OnResourceChanged;

                private void Start()
                {
                    _currentResource = _initialResource;
                    OnResourceChanged(_currentResource);
                }

                private void Update()
                {
                    AddResource(Time.deltaTime * _addResourceSpeed);
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
                    if (_currentResource - cost < 0)
                    {
                        _currentResource -= cost;
                        OnResourceChanged?.Invoke(_currentResource);
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}