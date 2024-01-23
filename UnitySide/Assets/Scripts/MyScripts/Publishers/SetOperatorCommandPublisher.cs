using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOperatorCommandPublisher : AbstractPublisher
{
    private float MapX;
    private float MapY;

    public void PublishOperatorLocation(float MapX, float MapY) 
    {
        this.MapX = MapX;
        this.MapY = MapY;
        PublisherAction();
    }

    public override void PublisherAction()
    {
        PublishMessage($"setoperator {MapX} {MapY}");
    }
}
