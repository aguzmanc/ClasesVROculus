using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    void OnTriggerEnter(Collider c) {
        if(c.tag == "Flecha"){
            c.GetComponent<Rigidbody>().isKinematic = true;
        }    
    }
}
