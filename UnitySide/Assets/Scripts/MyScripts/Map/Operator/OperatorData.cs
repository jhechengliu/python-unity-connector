using System.Collections;
using System.Collections.Generic;
//using System.Security.Policy;
using UnityEngine;

public class OperatorData : MonoBehaviour
{
    [SerializeField]
    private GameObject indicator;

    [SerializeField]
    private Outline outline;

    public Outline GetOutline() { return outline; }

    public GameObject GetIndicator() { return indicator; }
}
