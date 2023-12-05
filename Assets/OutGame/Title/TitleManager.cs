using System.Collections;
using System.Collections.Generic;
using TeamB_TD.SaveData;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Awake()
    {
        DataManager.Instance.Initialize();
    }
}
