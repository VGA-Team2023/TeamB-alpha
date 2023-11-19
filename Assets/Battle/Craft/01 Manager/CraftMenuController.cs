using UnityEngine;
using System;

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
                        {
                            _manager.HideMenu(_lastShowedType);
                        }

                        var craftable = GetMouseOverlappingCraftable();
                        _lastShowedType = craftable;
                        if (craftable == CraftType.Invalid) return;

                        _manager.ShowMenu(craftable, MousePosition);
                    }
                }

                private CraftType GetMouseOverlappingCraftable()
                {
                    if (!MouseUtility.GetMouseOverlappingCollider2D(out RaycastHit2D hit, _layerMask)) return CraftType.Invalid;

                    if (!hit.collider.TryGetComponent(out Craftable craftable)) return CraftType.Invalid;

                    return craftable.CraftType;
                }
            }
        }
    }
}