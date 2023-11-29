// 日本語対応
using Cysharp.Threading.Tasks;
using System.Threading;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        public interface ICommand
        {
            UniTask RunCommand(CancellationToken token = default); // コマンドを実行する待機可能。
        }
    }
}