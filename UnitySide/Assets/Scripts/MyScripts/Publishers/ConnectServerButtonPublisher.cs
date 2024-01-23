using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEditor;
using System;

public class ConnectServerButtonPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        Debug.Log($"{this.Topic} is speaking");
        PublishMessage($"connect");
    }
}