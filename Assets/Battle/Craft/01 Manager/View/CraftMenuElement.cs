using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftMenuElement : MonoBehaviour, IPointerClickHandler
            {
                //[SerializeField]
                //private Text _name;
                //[SerializeField]
                //private Text _level;
                [SerializeField]
                private Sprite[] _levelSprite;

                private Action OnClicked;

                public void Initialize(int level, Action onClicked)
                {
                    if (gameObject.TryGetComponent(out Image myImage))
                    {
                        myImage.sprite = _levelSprite[level % 3];
                    }
                    OnClicked = onClicked;
                }

                public void OnPointerClick(PointerEventData eventData)
                {
                    OnClicked?.Invoke();
                }
            }
        }
    }
}