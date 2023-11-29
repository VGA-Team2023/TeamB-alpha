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

                    private void Start()
                    {
                        foreach (var allyPrefab in _allyContainer.AllyPrefabs)
                        {
                            var view = Instantiate(_viewPrefab, _viewParent);
                            view.Initialize(allyPrefab);
                            AllyPlaceableManager.Instance.AddPlaceViewHolder(allyPrefab.ConstantParams.ID, view);
                        }
                    }
                }
            }
        }
    }
}