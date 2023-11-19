using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class MouseUtility
            {
                private static readonly List<RaycastResult> _raycastUIResults = new List<RaycastResult>();

                public static List<RaycastResult> GetMouseOverlappingUI()
                {
                    PointerEventData eventData = new PointerEventData(EventSystem.current);
                    Vector2 mousePosition = Input.mousePosition;
                    eventData.position = mousePosition;

                    EventSystem.current.RaycastAll(eventData, _raycastUIResults);
                    return _raycastUIResults;
                }

                public static bool GetMouseOverlappingCollider(out RaycastHit hit, LayerMask layerMask)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    return Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);
                }

                public static bool GetMouseOverlappingCollider2D(out RaycastHit2D hit, LayerMask layerMask)
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
                    hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                    return hit.collider != null;
                }
            }
        }
    }
}