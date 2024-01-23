using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPublisher : AbstractPublisher
{
    public void ClickPublish()
    {
        PublishMessage("click");
    }
}
