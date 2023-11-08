using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameResultViewer : MonoBehaviour
{
    [SerializeField] private Text _deadEnemyCount;
    [SerializeField] private Text _towerHP;

    public void DeadEnemyCountSet(int value)
    {
        _deadEnemyCount.text = $"殲滅数 : {value.ToString()}";
    }

    public void TowerHPSet(int value)
    {
        _towerHP.text = $"タワーHP : {value}";
    }
}
