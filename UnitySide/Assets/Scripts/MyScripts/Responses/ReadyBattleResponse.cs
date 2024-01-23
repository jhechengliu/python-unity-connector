using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyBattleResponse : AbstractResponse
{
    public override void ResponseToMessage(string responseMessage)
    {
        if (responseMessage == "success")
        {
            Debug.Log("Battle Ready!");
        }
        else
        {
            Debug.Log("Something went wrong with the ready battle command");
        }
    }
}
