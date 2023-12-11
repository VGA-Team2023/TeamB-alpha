using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftResourceManager : MonoBehaviour
            {
                private static CraftResourceManager _current;

                public static CraftResourceManager Current => _current;

                [SerializeField, Range(3f, 10f)]
                private float _maxResource = 3f;
                [SerializeField]
                private float _currentResource = 0f;
                [SerializeField]
                private bool _isDebugMode = false;

                public float MaxResource => _maxResource;
                public float CurrentResource => _currentResource;

                public event Action<float> OnResourceChanged;

                private void Awake()
                {
                    _current = this;
                }

                private void OnDestroy()
                {
                    _current = null;
                }

                public void AddResource(float value)
                {
                    var old = _currentResource;
                    _currentResource += value;
                    if (_currentResource > _maxResource)
                        _currentResource = _maxResource;

                    if (old != _currentResource)
                    {
                        OnResourceChanged?.Invoke(_currentResource);
                    }
                }

                public void UseResource(float value)
                {
                    if (_currentResource < value)
                    {
                        throw new ArgumentException(nameof(value));
                    }
                    _currentResource -= value;

                    OnResourceChanged?.Invoke(_currentResource);
                }

                public bool TryUseResource(float value)
                {
                    if (_isDebugMode) return true;

                    if (_currentResource < value)
                    {
                        return false;
                    }
                    _currentResource -= value;

                    OnResourceChanged?.Invoke(_currentResource);
                    return true;
                }
            }
        }
    }
}