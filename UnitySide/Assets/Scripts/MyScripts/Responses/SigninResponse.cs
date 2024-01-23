using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static AbstractResponse;

public class SigninResponse : AbstractResponse
{
    [SerializeField]
    private Button playAsAttackerButton;
    [SerializeField]
    private Button playAsDefenderButton;
    [SerializeField]
    private UserRegister userRegister;

    public override void ResponseToMessage(string responseMessage)
    {
        if (responseMessage.Length == 0)
            throw new System.Exception($"{typeof(SigninResponse)}: response message is empty.");
        else if (responseMessage == "args_len_error" || responseMessage == "already_signin" || responseMessage == "identity_error")
            Debug.Log($"{typeof(SigninResponse)}: {responseMessage}");
        else
        {
            SplitResponse(responseMessage);
            if (splittedResponse[0] == "success")
            {
                Debug.Log($"{typeof(SigninResponse)}: {responseMessage}");
                userRegister.SetOpponentPlayerName(splittedResponse[1]);
                userRegister.SetOpponentPlayerIdentity(splittedResponse[2]);
                SceneManager.LoadScene("ReadyScene");
            }
            else if (splittedResponse[0] == "occupied")
            {
                if (splittedResponse[1] == "attacker")
                {
                    Debug.Log($"{typeof(SigninResponse)}: {responseMessage}");
                    playAsAttackerButton.interactable = false;
                }
                else if (splittedResponse[1] == "defender")
                {
                    Debug.Log($"{typeof(SigninResponse)}: {responseMessage}");
                    playAsDefenderButton.interactable = false;
                }
                else
                    Debug.LogWarning($"{typeof(SigninResponse)}: {responseMessage}");
            }
        }
    }
}
