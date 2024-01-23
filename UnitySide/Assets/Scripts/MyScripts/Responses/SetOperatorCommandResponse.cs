using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetOperatorCommandResponse : AbstractResponse
{
    [SerializeField]
    private TextMeshProUGUI counter;
    public override void ResponseToMessage(string responseMessage)
    {
        // success_n_left
        string[] splittedresponseMessage = responseMessage.Split('_');

        if (splittedresponseMessage.Length != 3)
        {
            Debug.LogWarning("Length not equal to 3 How?");
        }
        else if (splittedresponseMessage[0] == "success" && splittedresponseMessage[2] == "left")
        {
            Debug.Log("command get");
            if (Int32.TryParse(splittedresponseMessage[1], out int countLeft))
            {
                Debug.Log($"Get CountLEft: {countLeft}");
                string displayText;
                if (countLeft == 0) { displayText = "Waiting For Opponent"; }
                else {displayText = $"Unplaced Operators: {countLeft}"; }
                counter.SetText(displayText);
            }
            else
            {
                Debug.LogWarning("Operator Count should be a int");
            }
        }
    }
}
