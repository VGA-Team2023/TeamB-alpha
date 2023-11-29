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
                    _resourceView.text = $"マナ : {((int)changedResource).ToString()} / {_resourceManager.MaxResource.ToString(".")}";
                }
                
                private void ApplyResourceSlider(float changedResource)
                {
                    float decimalPoint = changedResource % 1;
                    if (decimalPoint <= 0.05) _resourceSlider.value = 0;
                    else _resourceSlider.value = decimalPoint;

                }
            }
        }
    }
}