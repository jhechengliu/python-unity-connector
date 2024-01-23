using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickResponse : AbstractResponse
{
    public override void ResponseToMessage(string responseMessage)
    {
        if (responseMessage == "success")
        {
            Debug.Log("Click Success");
        }
        else
        {
            Debug.LogWarning("Click Failed");
        }
    }
}
