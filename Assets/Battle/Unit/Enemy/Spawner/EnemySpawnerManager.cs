using System.Collections.Generic;
using TeamB_TD.Battle.StageManagement;
using UnityEngine;

namespace TeamB_TD.Battle.Unit.Enemy
{
    [DefaultExecutionOrder(-110)]
    public class EnemySpawnerManager : MonoBehaviour
    {
        private static EnemySpawnerManager _current;
        public static EnemySpawnerManager Current => _current;

        private void Awake()
        {
            _current = this;
        }

        private void OnDestroy()
        {
            _current = null;
        }

        private HashSet<IStageCell> _spawnerCells = new HashSet<IStageCell>();
        public HashSet<IStageCell> SpawnerCells => _spawnerCells;
    }
}