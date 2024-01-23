using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class AbstractPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Std.String>
{
    protected RosSharp.RosBridgeClient.MessageTypes.Std.String message;
    protected string messageId;
    [SerializeField]
    protected ResponsesDictionary responsesDictionary;
    [SerializeField]
    protected AbstractResponse abstractResponse;
    [SerializeField]
    protected UserRegister userRegister;

    protected override void Start()
    {
        Topic = "/" + userRegister.GetTopicName();
        base.Start();
        message = new RosSharp.RosBridgeClient.MessageTypes.Std.String();
    }

    protected void PublishMessage(System.String data)
    {
        messageId = Guid.NewGuid().ToString();
        message.data = messageId + ' ' + data;
        Debug.Log($"Publishing Data: {message.data}");
        Publish(message);
        responsesDictionary.AddResponse(messageId, abstractResponse);
        Debug.Log($"{typeof(AbstractPublisher)}: Added id and response to dictionary");
    }

    public virtual void PublisherAction()
    {
        Debug.Log($"{this.Topic} is speaking");
        PublishMessage($"need to override!");
    }
}
