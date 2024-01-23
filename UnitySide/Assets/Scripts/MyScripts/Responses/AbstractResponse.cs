using UnityEngine;
using System;

public abstract class AbstractResponse : MonoBehaviour
{

    protected string[] splittedResponse;

    public virtual void ResponseToMessage(string responseMessage){}

    public void SplitResponse(string responseMessage)
    {
        splittedResponse = responseMessage.Split('_');
    }
}