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
                [SerializeField]
                private Text _name;
                [SerializeField]
                private Text _level;

                private Action OnClicked;

                public void Initialize(string name, int level, Action onClicked)
                {
                    _name.text = name;
                    _level.text = level.ToString();
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