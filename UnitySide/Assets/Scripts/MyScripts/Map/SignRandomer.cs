using RosSharp.RosBridgeClient.MessageTypes.Geometry;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignRandomer : MonoBehaviour
{
    [SerializeField]
    GameObject sign1;

    [SerializeField]
    GameObject sign2;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            sign1.SetActive(false);
        }
        else if (rand == 1)
        {
            sign2.SetActive(false);
        }
    }

    public enum Direction
    {
        PositiveX,
        PositiveY,
        NegativeX,
        NegativeY
    }

    public void SetRotation(Direction direction)
    {
        switch (direction)
        {
            case Direction.PositiveX:
                this.SetYRotation(Random.Range(225, 315));
                break;
            case Direction.PositiveY:
                this.SetYRotation(Random.Range(-45, 45));
                break;
            case Direction.NegativeX:
                this.SetYRotation(Random.Range(45, 135));
                break;
            case Direction.NegativeY:
                this.SetYRotation(Random.Range(135, 225));
                break;
        }
    }

    private void SetYRotation(float y)
    {
        sign1.transform.rotation = UnityEngine.Quaternion.Euler(0, y, 0);
        sign2.transform.rotation = UnityEngine.Quaternion.Euler(0, y, 0);
    }
}
