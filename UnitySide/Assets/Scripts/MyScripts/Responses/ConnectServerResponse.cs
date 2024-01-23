using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AbstractResponse;

public class ConnectServerResponse : AbstractResponse
{
    [SerializeField]
    private UserRegister userRegister;
    public override void ResponseToMessage(string responseMessage)
    {
        switch (responseMessage)
        {
            case "args_must_be_0":
                Debug.Log($"{typeof(ConnectServerResponse)}: args_must_be_0");
                // pop up error message
                break;
            case "full":
                Debug.Log($"{typeof(ConnectServerResponse)}: full");
                // pop up error message
                break;
            case "fatal_error":
                Debug.Log($"{typeof(ConnectServerResponse)}: fatal_error");
                // pop up error message
                break;
            default:
                Debug.Log($"{typeof(ConnectServerResponse)}: Topic name: {responseMessage}");
                userRegister.SetTopicName(responseMessage);
                SceneManager.LoadScene("SigninScene");
                break;
        }
    }
}
