using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bateEntero : MonoBehaviour
{    
    
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="piso")
        {
            transform.position= new Vector3(0.473f, 1.4f, -0.35f);
            transform.GetComponent<Rigidbody>().isKinematic=true;
        }
    }
}
