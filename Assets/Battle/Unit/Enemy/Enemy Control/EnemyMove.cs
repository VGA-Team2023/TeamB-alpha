using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using TeamB_TD.Battle.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace Unit
        {
            namespace Enemy
            {
                [Serializable]
                public class EnemyMove
                {
                    [SerializeField, Range(1f, 10f)]
                    private float _moveSpeed;
                    [SerializeField]
                    private ForwardObjectScanner _scanner;

                    private EnemyController _controller;

                    private List<StageCell> _path = new List<StageCell>();
                    private List<Vector2> _positions = new List<Vector2>(); // 経路用座標。

                    private Stage _stage;
                    private Vector3 _moveDir; // 移動用ベクトル。

                    public bool IsMovable => !_scanner.IsExistObject; // 進行方向にオブジェクトが存在する場合、移動できない。

                    public void Initialize(EnemyController controller, Stage stage, StageCell spawnerCell, StageCell goalCell)
                    {
                        _controller = controller;
                        _stage = stage;
                        if (!InitializePath(spawnerCell.YPos, spawnerCell.XPos, goalCell.YPos, goalCell.XPos))
                        {
                            throw new ArgumentException($"経路が見つかりませんでした。\n" +
                                $"StartPos X: {spawnerCell.XPos}, Y: {spawnerCell.YPos}, " +
                                $"EndPos X: {goalCell.XPos}, Y: {goalCell.YPos}");
                        }

                        _positions.Clear();
                        foreach (var cell in _path)
                        {
                            _positions.Add(cell.transform.position);
                        }

                        controller.transform.position = _positions[0];
                        StartMove();
                    }

                    public void Update(Transform transform)
                    {
                        _scanner.SetDir(_moveDir);
                        if (!IsMovable) return;

                        var gameSpeed = GameSpeedController.CurretGameSpeed;
                        transform.Translate(_moveDir.normalized * Time.deltaTime * _moveSpeed * gameSpeed);

                        // 左右の補正（行き過ぎた場合、目標地点に強制移動する。）
                        if (_moveDir.x >= 0f && transform.position.x > _currentTargetPosition.x ||
                            _moveDir.x <= 0f && transform.position.x < _currentTargetPosition.x)
                        {
                            var pos = transform.position;
                            pos.x = _currentTargetPosition.x;
                            transform.position = pos;
                        }
                        // 上下の補正（行き過ぎた場合、目標地点に強制移動する。）
                        if (_moveDir.y >= 0f && transform.position.y > _currentTargetPosition.y ||
                            _moveDir.y <= 0f && transform.position.y < _currentTargetPosition.y)
                        {
                            var pos = transform.position;
                            pos.y = _currentTargetPosition.y;
                            transform.position = pos;
                        }
                    }

                    private Vector2 _currentTargetPosition;

                    public async void StartMove()
                    {
                        // 無効条件 下記の条件どれか一つでも満たす場合、移動せず処理を終了する。
                        if (_positions == null || _positions.Count == 0)
                        {
                            return;
                        }

                        // 最後に訪れた地点を開始地点とする。
                        Vector2 lastPos = _controller.transform.position;
                        for (int i = 0; i < _positions.Count; i++)
                        {
                            try
                            {
                                // 現在の目的地を取得する。WaitMove等の関数内で現在の目的地を利用するため。
                                _currentTargetPosition = _positions[i];
                                // 目的地への方向ベクトルを取得。Update関数内で移動に使用する。
                                _moveDir = _positions[i] - lastPos;
                                // 目的地に到達するまで待機する。
                                await WaitMove(_controller.transform, lastPos, _positions[i],
                                    _controller.GetCancellationTokenOnDestroy());
                                // 目的地を新しい開始地点とする。
                                lastPos = _positions[i];
                            }
                            catch (OperationCanceledException)
                            {
                                Debug.Log("Canceled");
                                return;
                            }
                        }
                        EnemyCounter.Current.OnTowerInvasion(); // タワーに到着した。
                        GameObject.Destroy(_controller.gameObject);
                        return;
                    }

                    private async UniTask WaitMove(Transform origin,
                        Vector2 startPos, Vector2 targetPos, CancellationToken token)
                    {
                        if (startPos.x <= targetPos.x && // 右上
                            startPos.y <= targetPos.y)
                        {
                            await UniTask.WaitUntil(() =>
                                origin.position.x >= targetPos.x &&
                                origin.position.y >= targetPos.y,
                                cancellationToken: token);
                        }
                        else if (startPos.x >= targetPos.x && // 左上
                                 startPos.y <= targetPos.y)
                        {
                            await UniTask.WaitUntil(() =>
                                origin.position.x <= targetPos.x &&
                                origin.position.y >= targetPos.y,
                                cancellationToken: token);
                        }
                        else if (startPos.x <= targetPos.x && // 右下
                                 startPos.y >= targetPos.y)
                        {
                            await UniTask.WaitUntil(() =>
                                origin.position.x >= targetPos.x &&
                                origin.position.y <= targetPos.y,
                                cancellationToken: token);
                        }
                        else if (startPos.x >= targetPos.x && // 左下
                                 startPos.y >= targetPos.y)
                        {
                            await UniTask.WaitUntil(() =>
                                origin.position.x <= targetPos.x &&
                                origin.position.y <= targetPos.y,
                                cancellationToken: token);
                        }
                        _controller.transform.position = targetPos;
                    }

                    private bool InitializePath(int startY, int startX, int goalY, int goalX)
                    {
                        // ダイクストラ法でスタートから各セルへのコストを計算
                        int[,] cost = new int[_stage.StageData.GetLength(0), _stage.StageData.GetLength(1)];
                        for (int y = 0; y < _stage.StageData.GetLength(0); y++)
                        {
                            for (int x = 0; x < _stage.StageData.GetLength(1); x++)
                            {
                                cost[y, x] = int.MaxValue;
                            }
                        }

                        cost[startY, startX] = 0;
                        List<StageCell> openSet = new List<StageCell>();

                        StageCell startCell = _stage.StageData[startY, startX];
                        openSet.Add(startCell);

                        while (openSet.Count > 0)
                        {
                            StageCell currentCell = openSet[0];
                            openSet.RemoveAt(0);

                            if (currentCell.YPos == goalY && currentCell.XPos == goalX)
                            {
                                // ゴールに到達
                                // 経路を構築
                                BuildPath(startCell, currentCell);
                                return true;
                            }

                            foreach (var neighbor in GetNeighbors(currentCell))
                            {
                                int newCost = cost[currentCell.YPos, currentCell.XPos] + 1;

                                if (newCost < cost[neighbor.YPos, neighbor.XPos])
                                {
                                    cost[neighbor.YPos, neighbor.XPos] = newCost;
                                    neighbor.Parent = currentCell;

                                    // コストを計算してオープンセットに追加
                                    int f = newCost + Heuristic(neighbor, goalY, goalX);
                                    int index = 0;
                                    while (index < openSet.Count && f >= Heuristic(openSet[index], goalY, goalX))
                                    {
                                        index++;
                                    }
                                    openSet.Insert(index, neighbor);
                                }
                            }
                        }
                        return false;
                    }

                    private List<StageCell> GetNeighbors(StageCell cell)
                    {
                        List<StageCell> neighbors = new List<StageCell>();

                        int[] dy = { -1, 1, 0, 0 };
                        int[] dx = { 0, 0, -1, 1 };

                        for (int i = 0; i < 4; i++)
                        {
                            int ny = cell.YPos + dy[i];
                            int nx = cell.XPos + dx[i];

                            if (IsValidCell(ny, nx) && _stage.StageData[ny, nx].Status.HasFlag(StageCellStatus.Movable))
                            {
                                neighbors.Add(_stage.StageData[ny, nx]);
                            }
                        }

                        return neighbors;
                    }

                    private bool IsValidCell(int y, int x)
                    {
                        return y >= 0 && y < _stage.StageData.GetLength(0) && x >= 0 && x < _stage.StageData.GetLength(1);
                    }

                    private int Heuristic(StageCell cell, int goalY, int goalX)
                    {
                        // マンハッタン距離を使用
                        return Mathf.Abs(cell.YPos - goalY) + Mathf.Abs(cell.XPos - goalX);
                    }

                    private void BuildPath(StageCell startCell, StageCell goalCell)
                    {
                        _path.Clear();
                        StageCell current = goalCell;
                        while (current != startCell)
                        {
                            _path.Insert(0, current);
                            current = current.Parent;
                        }
                        _path.Insert(0, startCell);
                    }
                }
            }
        }
    }
}