using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoundPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("finishround");
    }
}
