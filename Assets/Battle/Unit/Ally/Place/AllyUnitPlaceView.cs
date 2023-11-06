using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Ally
            {
                public class AllyUnitPlaceView : MonoBehaviour
                {
                    [SerializeField]
                    private Text _nameText;
                    [SerializeField]
                    private Text _costText;

                    private AllyController _allyPrefab;

                    public AllyController AllyPrefab => _allyPrefab;

                    public void Initialize(AllyController allyPrefab)
                    {
                        _allyPrefab = allyPrefab;
                        _nameText.text = "Name: " + allyPrefab.Name;
                        _costText.text = "Cost: " + allyPrefab.Cost;
                    }
                }
            }
        }
    }
}