using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BattleServerResponse : AbstractResponse
{
    [SerializeField]
    private OperatorController operatorController;

    [SerializeField]
    private CheckSightCommandPublisher checkSightCommandPublisher;

    public override void ResponseToMessage(string responseMessage)
    {
        Debug.Log($"BattleServerResponse get msg: {responseMessage}");

        SplitResponse(responseMessage);
        if (splittedResponse.Length == 2 && splittedResponse[0] == "turn")
        {
            if (Int32.TryParse(splittedResponse[1], out int index))
            {
                Debug.Log($"Operator {index}'s turn");
                operatorController.SetOperatorActive(index);
                operatorController.SetBulletCount(OperatorController.MAX_BULLET_COUNT);
                operatorController.SetStamina(OperatorController.MAX_STAMINA);
                checkSightCommandPublisher.publishCheckSight(index);
            }
            else
            {
                Debug.LogWarning($"Operator Index must be a int");
            }
        }
        
    }
}
