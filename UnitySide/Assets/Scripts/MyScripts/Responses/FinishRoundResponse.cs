using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoundResponse : AbstractResponse
{
    [SerializeField]
    private OperatorController operatorController;

    public override void ResponseToMessage(string responseMessage)
    {
        if (responseMessage.Length == 1 && responseMessage == "success") 
        {
            Debug.Log("Round Finish Successfully");

            foreach (GameObject operatorObject in operatorController.GetAttackers())
            {
                operatorObject.GetComponent<OperatorData>().GetOutline().OutlineMode = Outline.Mode.OutlineHidden;
            }

            foreach (GameObject operatorObject in operatorController.GetDefenders()) 
            {
                operatorObject.GetComponent<OperatorData>().GetOutline().OutlineMode = Outline.Mode.OutlineHidden;
            }
        }
    }
}
