using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TeamB_TD.NovelGameEditor5;
using UnityEngine;

public class Reset : ICommand
{
    public Reset()
    {

    }
    public async UniTask RunCommand(CancellationToken token = default)
    {
        NovelData.Current.Reset();
        await UniTask.CompletedTask;
    }
}
