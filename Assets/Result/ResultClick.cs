﻿using TeamB_TD.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResultClick : MonoBehaviour ,IPointerClickHandler
{
    [SerializeField]
    private string _nextSceneName = default;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneTransition.instance.SceneTrans(_nextSceneName);
    }
}
