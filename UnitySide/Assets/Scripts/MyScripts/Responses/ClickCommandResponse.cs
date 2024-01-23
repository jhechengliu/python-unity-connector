using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCommandResponse : AbstractResponse
{
    [SerializeField]
    GameDirectorMain gameDirectorMain;
    public override void ResponseToMessage(string responseMessage)
    {

        string[] splittedResponseMessage = responseMessage.Split('_');

        if (splittedResponseMessage[0] == "success" && splittedResponseMessage.Length == 3)
        {
            if (!int.TryParse(splittedResponseMessage[1], out int ourCount) && (!int.TryParse(splittedResponseMessage[2], out int emenyCount)))
            {
                Debug.Log($"Get my count:{ourCount} emenyCount:{emenyCount}");
                gameDirectorMain.SetClickCount(ourCount, emenyCount);
            }
        }
    }
}
