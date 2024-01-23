using RosSharp.RosBridgeClient;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SendExitPublisher : AbstractPublisher
{

    private void OnApplicationQuit()
    {
        Topic = userRegister.GetTopicName();
        PublishMessage("exit");
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);        
    }
}
