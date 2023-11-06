using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class PlaceViewInitializer : MonoBehaviour
                {
                    [SerializeField]
                    private AllyPrefabContainer _allyContainer;
                    [SerializeField]
                    private AllyUnitPlaceView _viewPrefab;
                    [SerializeField]
                    private Transform _viewParent;

                    private void Awake()
                    {
                        foreach (var allyPrefab in _allyContainer.AllyPrefabs)
                        {
                            var view = GameObject.Instantiate(_viewPrefab, _viewParent);
                            view.Initialize(allyPrefab);
                        }
                    }
                }
            }
        }
    }
}