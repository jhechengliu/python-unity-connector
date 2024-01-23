using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendDirection : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    public enum ExtendDirectionEnum
    {
        XDirection,
        YDirection,
        Null
    }

    [SerializeField]
    private ExtendDirectionEnum direction = ExtendDirectionEnum.XDirection;

    public void SetExtendDirectionEnum(ExtendDirectionEnum direction)
    {
        this.direction = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (direction == ExtendDirectionEnum.XDirection)
        {
            target.transform.eulerAngles = Vector3.zero;
        }
        else if (direction == ExtendDirectionEnum.YDirection)
        {
            target.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            target.SetActive(false);
        }
    }

    public void SwapDirection()
    {
        if (direction == ExtendDirectionEnum.XDirection)
        {
            direction = ExtendDirectionEnum.YDirection;
        }
        else if (direction == ExtendDirectionEnum.YDirection)
        {
            direction = ExtendDirectionEnum.XDirection;
        }
    }

}
