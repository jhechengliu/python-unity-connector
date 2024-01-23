using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class DisplayPlayerNameAction : MonoBehaviour
{
    public Text playerName;
    public InputField display;

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PlayerPrefs.GetString("user_name");
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = display.text;
        PlayerPrefs.SetString("user_name", playerName.text);
        PlayerPrefs.Save();
    }

    
}
