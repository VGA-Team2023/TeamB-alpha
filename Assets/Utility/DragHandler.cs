// 日本語対応
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

namespace TeamB_TD
{
    namespace Utility
    {
        [Serializable]
        public class DragHandler : MonoBehaviour
        {
            public event Action<GameObject> OnButtonPressed;
            public event Action<List<RaycastResult>> OnButtonPressedUIAll;
            public event Action<GameObject> OnButtonReleased;
            public event Action<List<RaycastResult>> OnButtonReleasedUIAll;

            [SerializeField]
            private LayerMask _3DColliderLayerMask;
            [SerializeField]
            private LayerMask _2DColliderLayerMask;

            void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var mouseOverlappingUIs = GetMouseOverlappingUI();
                    if (mouseOverlappingUIs.Count > 0)
                    {
                        OnButtonPressedUIAll?.Invoke(mouseOverlappingUIs);
                        OnButtonPressed?.Invoke(mouseOverlappingUIs[0].gameObject); // 一番手前のUIのみ渡す。
                    }
                    else if (GetMouseOverlappingCollider(out RaycastHit mouseOverlappingCollider))
                    {
                        OnButtonPressed?.Invoke(mouseOverlappingCollider.collider.gameObject);
                    }
                    else if (GetMouseOverlapping2DCollider(out RaycastHit2D mouseOverlappingCollider2D))
                    {
                        OnButtonPressed?.Invoke(mouseOverlappingCollider2D.collider.gameObject);
                    }
                    else
                    {
                        OnButtonPressed?.Invoke(null);
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    var mouseOverlappingUIs = GetMouseOverlappingUI();
                    if (mouseOverlappingUIs.Count > 0)
                    {
                        OnButtonReleasedUIAll?.Invoke(mouseOverlappingUIs);
                        OnButtonReleased?.Invoke(mouseOverlappingUIs[0].gameObject); // 一番手前のUIのみ渡す。
                    }
                    else if (GetMouseOverlappingCollider(out RaycastHit mouseOverlappingCollider))
                    {
                        OnButtonReleased?.Invoke(mouseOverlappingCollider.collider.gameObject);
                    }
                    else if (GetMouseOverlapping2DCollider(out RaycastHit2D mouseOverlappingCollider2D))
                    {
                        OnButtonReleased?.Invoke(mouseOverlappingCollider2D.collider.gameObject);
                    }
                    else
                    {
                        OnButtonReleased?.Invoke(null);
                    }
                }
            }

            private List<RaycastResult> _results = new List<RaycastResult>();

            private List<RaycastResult> GetMouseOverlappingUI()
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                Vector2 mousePosition = Input.mousePosition;
                eventData.position = mousePosition;

                EventSystem.current.RaycastAll(eventData, _results);
                return _results;
            }

            private bool GetMouseOverlappingCollider(out RaycastHit hit)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                return Physics.Raycast(ray, out hit, Mathf.Infinity, _3DColliderLayerMask);
            }

            private bool GetMouseOverlapping2DCollider(out RaycastHit2D hit)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, _2DColliderLayerMask);

                return hit.collider != null;
            }
        }
    }
}