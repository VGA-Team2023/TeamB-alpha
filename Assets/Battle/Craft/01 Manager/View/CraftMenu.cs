using UnityEngine;
using Cysharp.Threading.Tasks;
using TeamB_TD.Battle.Unit.Ally;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            public class CraftMenu : MonoBehaviour
            {
                [SerializeField]
                private CraftMenuElement _prefab;

                private RectTransform _rectTransform = null;

                public RectTransform RectTransform => _rectTransform != null ? _rectTransform : _rectTransform = GetComponent<RectTransform>();

                // TODO: 要素数や要素のサイズに応じて高さや幅を調整できるようにする。

                public void Initialize(CraftableEffect effect)
                {
                    CreateView(effect);
                }

                public void OnShowMenu(AllyController ally)
                {
                    _ally = ally;
                }

                private AllyController _ally;

                private void CreateView(CraftableEffect effect)
                {
                    for (int i = 0; i < effect.Parameters.Length; i++)
                    {
                        var level = i + 1;
                        var view = GameObject.Instantiate(_prefab, transform);
                        view.Initialize(effect.name, level, () => OnClicked(level, effect));
                    }
                }
                public void OnClicked(int level, CraftableEffect effect)
                {
                    if (CraftResourceManager.Current &&
                        CraftResourceManager.Current.TryUseResource(level))
                    {
                        effect.RequestEffect(_ally, level, this.GetCancellationTokenOnDestroy());
                    }
                }
            }
        }
    }
}