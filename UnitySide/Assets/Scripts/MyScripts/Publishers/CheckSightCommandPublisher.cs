using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSightCommandPublisher : AbstractPublisher
{
    public void publishCheckSight(int operatorIndex)
    {
        PublishMessage($"checksight {operatorIndex}");
    }
}
