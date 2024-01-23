using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUpdateCommandPublisher : AbstractPublisher
{
    public override void PublisherAction()
    {
        PublishMessage("mapupdate");
    }

    float timer = 0;
    bool startTimer = true;
    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > 1) // Delay A bit
            {
                PublisherAction();
                startTimer = false;
            }

        }
    }
}
