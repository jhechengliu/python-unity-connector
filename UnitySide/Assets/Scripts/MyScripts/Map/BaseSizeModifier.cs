using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BaseSizeModifier : MonoBehaviour
{
    [SerializeField]
    private GameObject basePlane;

    public GameObject GetBasePlane() { return basePlane; }
    void Start()
    {
        
    }

    public void SetBaseSize(int x, int y)
    {
        transform.localScale = new Vector3(((float)y)/10, 1, ((float)x)/10);
    }

}
