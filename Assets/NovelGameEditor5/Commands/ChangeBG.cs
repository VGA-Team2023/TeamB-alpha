using Cysharp.Threading.Tasks;
using System.Threading;
using TeamB_TD.NovelGameEditor5;
using UnityEngine;

public class ChangeBG : ICommand
{
    private int _bgKinds = 0;
    public ChangeBG(string[] commandArgs)
    {
        if (int.TryParse(commandArgs[0], out int bgKinds))
        {
            _bgKinds = bgKinds;
        }
        else
        {
            Debug.Log($"{commandArgs[0]}をintに直せませんでした");
        }
    }

    private async UniTask UpdateBG(int bgId)
    {
        NovelData.Current.BG.sprite = NovelData.Current.BGSprites[bgId];
        await UniTask.CompletedTask;
    }

#pragma warning disable 1998
    public async UniTask RunCommand(CancellationToken token = default)
    {
        await UpdateBG(_bgKinds);
    }
#pragma warning restore 1998
}
