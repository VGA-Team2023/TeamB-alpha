// 日本語対応
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

namespace TeamB_TD
{
    namespace NovelGameEditor5.Commands
    {
        public class LoadScene : ICommand
        {
            private string _sceneName;

            public LoadScene(string[] parametorData)
            {
                _sceneName = parametorData[0];
            }

#pragma warning disable 1998
            public async UniTask RunCommand(CancellationToken token = default)
            {
                SceneManager.LoadScene(_sceneName);
            }
#pragma warning restore 1998
        }
    }
}