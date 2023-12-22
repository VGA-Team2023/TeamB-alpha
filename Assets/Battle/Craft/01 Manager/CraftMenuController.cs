using UnityEngine;
using System;
using TeamB_TD.Battle.Unit.Ally;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftMenuController : MonoBehaviour
            {
                [SerializeField]
                private CraftMenuManager _manager;
                [SerializeField]
                private LayerMask _layerMask;

                private CraftType _lastShowedType; // 最後に表示したタイプ

                private Vector2 MousePosition => Input.mousePosition;

                // メニューとマウスカーソルが重なっているかどうか。
                // 結構沢山検索が走っているので頻繁に使用しない。（アイデアが湧き次第改善する。）
                private bool IsMouseOverlappingMenu
                {
                    get
                    {
                        var uiList = MouseUtility.GetMouseOverlappingUI();
                        foreach (var ui in uiList)
                        {
                            if (ui.gameObject.TryGetComponent(out CraftMenu menu)) return true;
                        }
                        return false;
                    }
                }

                private void Update()
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (IsMouseOverlappingMenu) return;

                        if (_lastShowedType != CraftType.Invalid)
                            _manager.HideMenu(_lastShowedType);

                        if (!TryGetMouseOverlappingCraftable(out Craftable craftable)) return;
                        _lastShowedType = craftable.CraftType;

                        if (craftable.CraftType == CraftType.Invalid) return;

                        AllyController ally = craftable.Ally;
                        if (ally == null) return;

                        _manager.ShowMenu(ally, craftable.CraftType, MousePosition);
                    }
                }

                private bool TryGetMouseOverlappingCraftable(out Craftable result)
                {
                    result = null;
                    if (!MouseUtility.GetMouseOverlappingCollider2D(out RaycastHit2D hit, _layerMask)) return false;

                    return hit.collider.TryGetComponent(out result);
                }
            }
        }
    }
}