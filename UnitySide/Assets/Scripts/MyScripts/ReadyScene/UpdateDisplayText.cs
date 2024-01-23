using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDisplayText : MonoBehaviour
{
    [SerializeField]
    private Text userNameText;
    [SerializeField]
    private Text userIdentityText;
    [SerializeField]
    private Text opponentNameText;
    [SerializeField]
    private Text opponentIdentityText;
    [SerializeField]
    private UserRegister userRegister;

    void Start()
    {
        userNameText.text = "YOUR NAME:\n" + userRegister.GetPlayerName();
        userIdentityText.text = "YOU PLAY AS:\n" + userRegister.GetPlayerIdentity();
        if (userRegister.GetOpponentPlayerName() != "none" && userRegister.GetOpponentPlayerIdentity() != "none")
        {
            opponentNameText.text = "OPPONENT NAME:\n" + userRegister.GetOpponentPlayerName();
            opponentIdentityText.text = "OPPONENT PLAYS AS:\n" + userRegister.GetOpponentPlayerIdentity();
        }
        else
        {
            opponentNameText.text = "OPPONENT NAME:\n";
            opponentIdentityText.text = "OPPONENT PLAYS AS:\n";
        }
        Debug.Log($"{typeof(UpdateDisplayText)}: {userRegister.GetPlayerName()}, {userRegister.GetPlayerIdentity()}, {userRegister.GetOpponentPlayerName()}, {userRegister.GetOpponentPlayerIdentity()}");
    }
}
