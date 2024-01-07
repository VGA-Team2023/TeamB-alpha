using System.Collections.Generic;
using TeamB_TD.NovelGameEditor5;
using TeamB_TD.SaveData;
using UnityEngine;

public class SelectEnding : MonoBehaviour
{
    [SerializeField, Header("Runner")]
    private GameObject _runner = default;

    private Ending1 _ending1 = default;
    private Ending2 _ending2 = default;
    private Ending3 _ending3 = default;
    private Ending4 _ending4 = default;
    private Ending5 _ending5 = default;
    private Ending6 _ending6 = default;

    private List<EndingBase> _endingCollection = default;

    [Header("デバッグ用")]
    [SerializeField]
    private bool _isDebug = false;

    [SerializeField]
    private int _endingId = 0;

    private void Awake()
    {
        _endingCollection = new List<EndingBase>(6);

        _ending1 = _runner.GetComponent<Ending1>();
        _endingCollection.Add(_ending1);

        _ending2 = _runner.GetComponent<Ending2>();
        _endingCollection.Add(_ending2);

        _ending3 = _runner.GetComponent<Ending3>();
        _endingCollection.Add(_ending3);

        _ending4 = _runner.GetComponent<Ending4>();
        _endingCollection.Add(_ending4);

        _ending5 = _runner.GetComponent<Ending5>();
        _endingCollection.Add(_ending5);

        _ending6 = _runner.GetComponent<Ending6>();
        _endingCollection.Add(_ending6);

        if (_isDebug)
        {
            SwitchEnding(_endingId - 1);
        }
        else
        {
            SwitchEnding(DataManager.Instance.PlayerData._favoriteUnitId - 1);
        }
    }
    private void Start()
    {
        

        //switch (DataManager.Instance.PlayerData._favoriteUnitId)
        //{
        //    case 1:
        //        SwitchEnding(num);
        //        break;
        //    case 2:
        //        SwitchEnding(num);
        //        break;
        //    case 3:
        //        SwitchEnding(num);
        //        break;
        //    case 4:
        //        SwitchEnding(3);
        //        break;
        //    case 5:
        //        SwitchEnding(4);
        //        break;
        //    case 6:
        //        SwitchEnding(5);
        //        break;
        //    default:
        //        Debug.Log($"{DataManager.Instance.PlayerData._favoriteUnitId}が想定範囲外です。");
        //        break;
        //}
    }

    private void SwitchEnding(int endingId)
    {
        for (int i = 0; i < _endingCollection.Count; i++)
        {
            if (i == endingId)
            {
                _endingCollection[i].enabled = true;
            }
            else
            {
                _endingCollection[i].enabled = false;
            }
        }
    }
}
