using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGMSample : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.BGM.Play("BGM", "BGM_001_battle");
    }

    void Update()
    {
        
    }
}
