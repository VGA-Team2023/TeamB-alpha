using TeamB_TD.Battle.Unit.VFX;
using UnityEngine;
using UnityEngine.UIElements;

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

            [SerializeField]
            private FlagBuffVFX _flagBuffVFXPrefab;

            [SerializeField]
            private GameObject _bombVFXPrefab;

            private void Awake()
            {
                _current = this;
            }

            public FlagBuffVFX RequestFlagBuffVFX(float lifeTime, Vector2 position)
            {
                if (!_flagBuffVFXPrefab)
                {
                    Debug.Log("_flagBuffVFXPrefab is Missing");
                    return null;
                }
                var instance = Instantiate(_flagBuffVFXPrefab, position, _flagBuffVFXPrefab.transform.rotation);
                instance.Initialize(lifeTime);
                return instance;
            }

            public void RequestDamageVFX(float damageValue, Vector2 position)
            {
                if (!_useDamageVFX)
                {
                    return;
                }
                if (!_damageVFXPrefab)
                {
                    Debug.Log("_damageVFXPrefab is Missing");
                    return;
                }
                var instance = Instantiate(_damageVFXPrefab, position, Quaternion.identity, _uiVFXParent);
                instance.Initialize(damageValue);
            }

            public void RequestBombVFX(Vector2 position)
            {
                if (!_bombVFXPrefab)
                {
                    Debug.Log("_bombVFXPrefab is Missing");
                    return;
                }
                var instance = Instantiate(_bombVFXPrefab, position, Quaternion.identity);
            }
        }
    }
}