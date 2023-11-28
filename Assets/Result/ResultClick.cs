using UnityEngine;
using UnityEngine.EventSystems;

public class ResultClick : MonoBehaviour ,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("クリックされた");
    }
}
