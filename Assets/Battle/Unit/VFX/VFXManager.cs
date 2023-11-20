using TeamB_TD.Battle.Unit.VFX;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        public class VFXManager : MonoBehaviour
        {
            private static VFXManager _current;
            public static VFXManager Current => _current;

            [SerializeField]
            private Transform _uiVFXParent;

            [SerializeField]
            private bool _useDamageVFX = true;
            [SerializeField]
            private DamageVFX _damageVFXPrefab;

            private void Awake()
            {
                _current = this;
            }

            public void RequestDamageVFX(float damageValue, Vector2 position)
            {
                if (!_useDamageVFX) return;
                var instance = Instantiate(_damageVFXPrefab, position, Quaternion.identity, _uiVFXParent);
                instance.Initialize(damageValue);
            }
        }
    }
}