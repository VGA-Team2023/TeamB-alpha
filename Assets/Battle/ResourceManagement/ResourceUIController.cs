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

                private void Start()
                {
                    _resourceManager.OnResourceChanged += ApplyResourceView;
                    ApplyResourceView(_resourceManager.CurrentResource);
                }

                private void ApplyResourceView(float changedResource)
                {
                    _resourceView.text = $"Resource: {changedResource.ToString("00.00")} / {_resourceManager.MaxResource.ToString(".")}";
                }
            }
        }
    }
}