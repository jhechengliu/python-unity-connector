using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;

public class AbstractSubscriber : UnitySubscriber<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    protected string responseString;
    protected bool isMessageReceived;
    [SerializeField]
    protected ResponsesDictionary responsesDictionary;
    [SerializeField]
    protected UserRegister userRegister;

    protected override void Start()
    {
        Topic = "/server_" + userRegister.GetTopicName();
        base.Start();
    }

    protected void Update()
    {
        if (isMessageReceived)
            ProcessMessage();
    }

    protected virtual void ProcessMessage()
    {   
        isMessageReceived = false;
        if (this.responseString != null)
        {
            responsesDictionary.CheckResponse(this.responseString);
        }
    }

    protected override void ReceiveMessage(RosSharp.RosBridgeClient.MessageTypes.Std.String message)
    {
        responseString = message.data;
        Debug.Log($"AbstractSubscriber Got: {responseString}");
        isMessageReceived = true;
    }
}
