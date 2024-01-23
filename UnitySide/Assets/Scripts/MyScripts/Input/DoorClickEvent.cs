using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]
    private DoorOpenAnimatorController controller;

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Open the door");
        // controller.PlayOpenNegativeAnimation();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("Close the Door");
        // controller.PlayCloseAnimation();
    }
}
