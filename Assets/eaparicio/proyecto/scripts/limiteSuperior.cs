using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limiteSuperior : MonoBehaviour
{
    void Start()
    {
        
    }
   
    private void OnTriggerEnter(Collider other) {
        if (other.name=="bate" || other.name=="martillo")
        {
            other.GetComponentInChildren<bate>().Golpear();
            other.GetComponentInChildren<bate>().golpear=true;
        }
    }
}
