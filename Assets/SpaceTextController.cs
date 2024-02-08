using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpaceTextController : MonoBehaviour
{
    [SerializeField] private GameObject _spaceKeyText = default;
    void Start()
    {
        _spaceKeyText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _spaceKeyText.gameObject.SetActive(false);
        }
    }
}
