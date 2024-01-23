using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommandPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("move 3 1 1");
    }
}
