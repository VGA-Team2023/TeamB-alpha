using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace ResourceManagement
        {
            public class ResourceUIController : MonoBehaviour
            {
                [SerializeField]
                private ResourceManager _resourceManager;
                [SerializeField]
                private Text _resourceView;
                [SerializeField]
                private Slider _resourceSlider;

                private void Start()
                {
                    _resourceManager.OnResourceChanged += ApplyResourceView;
                    _resourceManager.OnResourceChanged += ApplyResourceSlider;
                    ApplyResourceView(_resourceManager.CurrentResource);
                    ApplyResourceSlider(_resourceManager.CurrentResource);
                }

                private void ApplyResourceView(float changedResource)
                {
                    _resourceView.text = $"マナ : {changedResource.ToString("00.00")} / {_resourceManager.MaxResource.ToString(".")}";
                }
                
                private void ApplyResourceSlider(float changedResource)
                {
                    float decimalPoint = changedResource % 1;
                    _resourceSlider.value = decimalPoint;
                }
            }
        }
    }
}