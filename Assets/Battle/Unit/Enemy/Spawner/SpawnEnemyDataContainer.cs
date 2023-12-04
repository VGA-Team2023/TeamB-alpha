using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using TeamB_TD.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                public class SpawnEnemyDataContainer
                {
                    // データは配列で管理する。
                    // IndexとIDは同義として扱う。

                    private static SpawnEnemyData[][] _spawnData = // 全てのスポーンデータ
                    {
                        new SpawnEnemyData[] // 一スポナー分のデータ
                        {
                            //TODO:α用に引数いじったのでリファクタする
                            new SpawnEnemyData(0,4f) , // 一体分のデータ（例: EnemyID 0をバトル開始後 1秒後に生成する。）
                            new SpawnEnemyData(1,8f) , // （例: EnemyID 1をバトル開始後 2秒後に生成する。）
                            new SpawnEnemyData(2,10f) , // （例: EnemyID 2をバトル開始後 3秒後に生成する。）
                            new SpawnEnemyData(3,12f) , // （例: EnemyID 3をバトル開始後 4秒後に生成する。）
                        },
                    };

                    public static SpawnEnemyData[][] SpawnData => _spawnData;

                    public SpawnEnemyData[] GetSpawnData(int id)
                    {

                        if (!ArrayUtility.IsIndexInRange(_spawnData, id))
                            return null;
                        // throw new ArgumentOutOfRangeException(nameof(id));

                        return _spawnData[id];
                    }

                    private static bool _isUseGoogleSheet = false;
                    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
                    public static async void Initialize()
                    {
                        var oldSceneName = SceneManager.GetActiveScene().name;

                        if (!_isUseGoogleSheet) return;
                        _spawnData = null;
                        var sheetID = "1AXejdAP8NIDD7g9WwsFJ0UVyeUCqJSvRw_YN-4CkyLw";
                        var sheetNames = new string[]
                        {
                            "Sample Sheet",
                            "シート1",
                            "シート2",
                            "シート3",
                            "シート4",
                            "シート5",
                            "シート6",
                            "シート7",
                            "シート8",
                        };

                        var cts = new CancellationTokenSource();
                        UniTask<List<string[]>>[] tasks = new UniTask<List<string[]>>[sheetNames.Length];

                        TimeOutCancel(cts);
                        for (int i = 0; i < sheetNames.Length; i++)
                        {
                            tasks[i] = GoogleSheetsLoader.LoadGoogleSheetsAsync(sheetID, sheetNames[i], 1, cts.Token);
                        }

                        List<string[]>[] results = await UniTask.WhenAll(tasks);

                        _spawnData = new SpawnEnemyData[sheetNames.Length][];
                        for (int i = 0; i < sheetNames.Length; i++)
                        {
                            _spawnData[i] = results[i].ToSpawnEnemyData();
                        }

                        SceneManager.LoadScene(oldSceneName);
                    }

                    private async static void TimeOutCancel(CancellationTokenSource cts)
                    {
                        await UniTask.Delay(10000);
                        cts.Cancel();
                    }
                }

                public static class SpawnEnemyDataConverter
                {
                    public static SpawnEnemyData[] ToSpawnEnemyData(this List<string[]> input)
                    {
                        SpawnEnemyData[] result = new SpawnEnemyData[input.Count];
                        for (int i = 0; i < input.Count; i++)
                        {
                            result[i] = input[i].ToSpawnEnemyData();
                        }
                        return result;
                    }

                    public static SpawnEnemyData ToSpawnEnemyData(this string[] input)
                    {
                        var enemyID = int.Parse(input[0]);
                        var spawnTime = float.Parse(input[1]);

                        return new SpawnEnemyData(enemyID, spawnTime);
                    }
                }
            }
        }
    }
}