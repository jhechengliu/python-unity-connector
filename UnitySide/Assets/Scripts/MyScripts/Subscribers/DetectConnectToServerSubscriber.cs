using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class DetectConnectToServerSubscriber : AbstractSubscriber
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    protected override void ProcessMessage()
    {
        Debug.Log($"Received message: {responseString}");
        if (responseString == "safe"){}
        else if (responseString == "boom")
        {
            QuitGame();
        }
        isMessageReceived = false;  
    }

    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
