using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperatorClickEvent : MonoBehaviour, IPointerClickHandler
{

    private FinishRoundPublisher finishRoundPublisher;

    [SerializeField]
    private GameObject indicator;

    private void Update()
    {
        if (finishRoundPublisher != null) { finishRoundPublisher = GameObject.Find("FinishRoundCommand").GetComponent<FinishRoundPublisher>(); }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (indicator.activeSelf == true)
        {
            finishRoundPublisher.PublisherAction();
            indicator.SetActive(false);
        }
    }
}
