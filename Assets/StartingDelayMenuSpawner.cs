using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDelayMenuSpawner : MonoBehaviour
{
    [SerializeField] GameObject startingDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(startingDisplay, this.transform.position, Quaternion.identity);
    }
}
