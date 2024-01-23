using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestCommandPublisher : AbstractPublisher
{
    public void PublishRequest()
    {
        PublishMessage("request");
    }
}
