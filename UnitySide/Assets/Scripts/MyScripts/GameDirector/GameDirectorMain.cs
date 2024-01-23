using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorMain : MonoBehaviour
{
    [SerializeField]
    private RequestCommandPublisher requestPublisher;

    

    private int emenyClickCount;
    private int myClickCount;

    public int GetEmenyClickCount() { return  emenyClickCount; }
    public int GetMyClickCount() { return myClickCount;}
    public void SetClickCount(int myCount, int emenyCount) { myClickCount = myCount; emenyClickCount = emenyCount; }

    // Next update in second
    private int nextUpdate = 1;

    // Update is called once per frame
    void Update()
    {

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

    }

    // Update is called once per second
    void UpdateEverySecond()
    {
        requestPublisher.PublishRequest();
    }
}
