using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class EventPublisher : UnityPublisher<MessageTypes.Std.String>
    {
        private String message;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            message = new String();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                message.data = "hello world";
                Publish(message);
            }
        }
    }
}

