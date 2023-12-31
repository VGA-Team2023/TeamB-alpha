﻿using System;
using System.Threading;
using TeamB_TD.Battle.StageManagement;
using TeamB_TD.Battle.Unit.Ally;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Craft
        {
            [CreateAssetMenu(fileName = "Wall Effect", menuName = "ScriptableObjects/Craftable Effect/Wall Effect", order = 0)]
            public class WallEffect : CraftableEffect
            {
                [SerializeField]
                private WallParam[] _wallParams;

                public WallParam[] WallParams => _wallParams;
                public override CraftableParameter[] Parameters => _wallParams;

                public override CraftType CraftType => CraftType.Wall;

                public override void RequestEffect(AllyController user, int level, CancellationToken token = default)
                {
                    base.RequestEffect(user, level, token);
                    var index = level - 1;
                    var param = _wallParams[index];
                    PlayEffect(user, param);
                }

                private void PlayEffect(AllyController user, WallParam param)
                {
                    Debug.Log(param.ToString());
                    // TODO: 指定の位置に壁を召喚する。
                    // 指定の位置とは使用者の1マス前方とする。
                    // 前方の定義: 使用者の左右上下のマスの中で最もスポナーが近いマス。

                    var stageController = StageManagement.StageController.Current;
                    var nearestSpawnerCell = stageController.GetNearestSpawnerCell(user.GroundCell);
                    if (nearestSpawnerCell == null) return; // 失敗。

                    var wallPrefab = param.WallUnitPrefab;
                    var position = nearestSpawnerCell.WorldPosition /*+ _placeOffset*/;
                    var instance = Instantiate(wallPrefab, position, Quaternion.identity);
                    instance.Initialize(param.WallLife);
                }
            }
        }
    }
}