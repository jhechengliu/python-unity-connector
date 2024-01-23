using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OperatorMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private OperatorAnimationController animationController;

    // python loc
    private float targetX;
    private float targetY;

    private bool moving = false;

    private Vector3 lastDirNormalized;

    [SerializeField]
    private float jumpHeight;


    private void MoveALittle(float x, float z) // Unity loc
    {
        if (moveSpeed == 0)
        {
            moveSpeed = 0.00001f;
        }
        Vector3 startLoc = gameObject.transform.position;
        Vector3 targetLoc = new Vector3(x, 0, z);
        Vector3 dirNormalized = targetLoc - startLoc;
        dirNormalized.Normalize();

        if (lastDirNormalized != dirNormalized)
        {
            moving = false;
            animationController.PlayIdleAnimation();
            return;
        }
        lastDirNormalized = dirNormalized;

        
        gameObject.transform.rotation = Quaternion.LookRotation(dirNormalized);
        transform.position = transform.position + dirNormalized * moveSpeed * Time.deltaTime;
    }

    public void Move(float targetX, float targetY)
    {
        if (moving)
        {
            Debug.LogWarning("Operator is still moving");
        }
        else
        {
            Debug.Log($"Moving to {targetX}, {targetY}");
            this.targetX = targetX;
            this.targetY = targetY;
            animationController.PlayRunAnimation();
            lastDirNormalized = new Vector3(targetY, 0, targetX) - gameObject.transform.position;
            lastDirNormalized.Normalize();
            moving = true;
        }
        
    }

    private void Update()
    {
        if (moving)
        {
            MoveALittle(targetY, targetX);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WindowBase>() != null)
        {
            animationController.PlayJumpAnimation();
        }
    }






}
