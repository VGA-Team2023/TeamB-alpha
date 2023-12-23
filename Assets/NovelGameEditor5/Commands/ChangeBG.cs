using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TeamB_TD.NovelGameEditor5;
using UnityEngine;

public class ChangeBG : ICommand
{
    private int _bgKinds = 0;
    public ChangeBG(string[] commandArgs)
    {
        if(int.TryParse(commandArgs[0], out int bgKinds))
        {
            _bgKinds = bgKinds;
        }
        else
        {
            Debug.Log($"{commandArgs[0]}をintに直せませんでした");
        }
    }

    private void UpdateBG(int bgId)
    {
        NovelData.Current.BG.sprite = NovelData.Current.BGSprites[bgId];
    }
    public async UniTask RunCommand(CancellationToken token = default)
    {
        UpdateBG(_bgKinds);
        await UniTask.CompletedTask;
    }
}
