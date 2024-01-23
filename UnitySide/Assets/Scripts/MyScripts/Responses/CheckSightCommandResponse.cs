using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MapUpdateResponse;

public class CheckSightCommandResponse : AbstractResponse
{
    [SerializeField]
    private OperatorController operatorController;

    [SerializeField]
    private UserRegister userRegister;

    public override void ResponseToMessage(string responseMessage)
    {
        splittedResponse = responseMessage.Split('_');
        string heading = splittedResponse[0];
        string json_str = "";
        for (int i = 1; i < splittedResponse.Length; i++)
        {
            json_str += splittedResponse[i];
            json_str += "_";
        }

        if (splittedResponse.Length == 2 && heading == "success")
        {
            InSightData inSightData = JsonConvert.DeserializeObject<InSightData>(json_str);
            List<int> insight = inSightData.insight;
            for (int index = 0; index < userRegister.GetMaxOperatorCount(); index++)
            {
                if (userRegister.GetOpponentPlayerIdentity() == "attacker")
                {
                    Outline outline = operatorController.GetAttackers()[index].GetComponent<Outline>();
                    if (outline != null)
                    {
                        if (insight.Contains(index))
                        {
                            outline.enabled = true;
                        }
                        else
                        {
                            outline.enabled = false;
                        }
                        
                    }
                }
            }
        }
    }

    private class InSightData
    {
        public List<int> insight;
    }
}
