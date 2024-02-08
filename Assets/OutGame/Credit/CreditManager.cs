using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _firstCredit = default;

    [SerializeField]
    private GameObject _nextCredit = default;
    void Start()
    {
        _firstCredit.SetActive(true);
        _nextCredit.SetActive(false);
    }

    public void ActiveNextCredit()
    {
        _nextCredit.SetActive(true);
        _firstCredit.SetActive(false);
    }

    public void BackFirstCredit()
    {
        _nextCredit.SetActive(false);
        _firstCredit.SetActive(true);
    }
}
