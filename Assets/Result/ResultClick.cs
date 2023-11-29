using TeamB_TD.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResultClick : MonoBehaviour ,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("クリックされた");
        SceneTransition.instance.SceneTrans("StageSelect");
    }
}
