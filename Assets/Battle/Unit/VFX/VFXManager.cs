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

            private void Awake()
            {
                _current = this;
            }

            [SerializeField]
            private DamageVFX _damageVFXPrefab;

            public void RequestDamageVFX(float damageValue, Vector2 position)
            {
                var instance = Instantiate(_damageVFXPrefab, position, Quaternion.identity, _uiVFXParent);
                instance.Initialize(damageValue);
            }
        }
    }
}