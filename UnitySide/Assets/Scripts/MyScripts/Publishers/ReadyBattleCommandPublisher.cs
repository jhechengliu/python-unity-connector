using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyBattleCommandPublisher : AbstractPublisher
{
    [SerializeField]
    private OperatorController controller;

    private bool hasPublished = false;
    private void Update()
    {
        if (controller.GetAttackers() != null && controller.GetDefenders() != null && !hasPublished)
        {
            PublishMessage("readybattle");
            hasPublished = true;
        }
    }
}
