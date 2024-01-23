using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePlaneClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Cube Clicked");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Cube Down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Cube Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Cube Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Cube Up");
    }
}
