using System.Collections.Generic;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftMenuManager : MonoBehaviour
            {
                [SerializeField]
                private CraftManager _craftManager;
                [SerializeField]
                private Transform _menuParent;

                [Space(10f)]
                [SerializeField]
                private CraftMenu _flagMenuPrefab;
                [SerializeField]
                private CraftMenu _bombMenuPrefab;
                [SerializeField]
                private CraftMenu _MakibisiMenuPrefab;
                [SerializeField]
                private CraftMenu _wallMenuPrefab;
                [SerializeField]
                private CraftMenu _portionMenuPrefab;
                [SerializeField]
                private CraftMenu _cannonMenuPrefab;

                private Dictionary<CraftType, CraftMenu> _craftMenuDic = new Dictionary<CraftType, CraftMenu>();
                public IReadOnlyDictionary<CraftType, CraftMenu> CraftMenuDic => _craftMenuDic;

                private void Start()
                {
                    CreateMenu(_flagMenuPrefab, CraftType.Flag);
                    CreateMenu(_bombMenuPrefab, CraftType.Bomb);
                    CreateMenu(_MakibisiMenuPrefab, CraftType.Makibisi);
                    CreateMenu(_wallMenuPrefab, CraftType.Wall);
                    CreateMenu(_portionMenuPrefab, CraftType.Portion);
                    CreateMenu(_cannonMenuPrefab, CraftType.Cannon);
                }

                public void ShowMenu(AllyController ally, CraftType craftType, Vector2 position)
                {
                    var menu = _craftMenuDic[craftType];
                    menu.RectTransform.position = position;
                    menu.OnShowMenu(ally);
                    menu.gameObject.SetActive(true);
                }

                public void HideMenu(CraftType craftType)
                {
                    var menu = _craftMenuDic[craftType];
                    menu.gameObject.SetActive(false);
                }

                private void CreateMenu(CraftMenu prefab, CraftType type)
                {
                    var effect = _craftManager.Effects[type];
                    var instance = Instantiate(prefab, _menuParent.transform);
                    instance.Initialize(effect);
                    _craftMenuDic.Add(type, instance);

                    instance.gameObject.SetActive(false); // 生成時は非表示にする。
                }
            }
        }
    }
}