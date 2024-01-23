using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BreakEffect : MonoBehaviour
{
    [SerializeField]
    ParticleSystem thisParticleSystem;


    public void Break()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            thisParticleSystem.Play();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<OperatorMove>() != null) 
        {
            Break();
        }
        // 
    }
}
