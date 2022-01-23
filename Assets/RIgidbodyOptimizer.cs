using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIgidbodyOptimizer : MonoBehaviour
{
    [SerializeField] Rigidbody[] rbs;

    private void Start()
    {
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].isKinematic = true;
            rbs[i].detectCollisions = false;
        }
    }
   public void ActivateRBs()
    {
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].isKinematic = false;
            rbs[i].detectCollisions = true;
        }
        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateRBs();
        }
    }
}
