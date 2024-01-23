using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneResponse : AbstractResponse
{
    public override void ResponseToMessage(string responseMessage)
    {
        if (responseMessage == "start_battle")
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
