using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquina : MonoBehaviour
{
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.name=="bate")
        {
            other.GetComponentInChildren<bate>().NoGolpear();
        }
    }

}
