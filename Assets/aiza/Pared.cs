using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Flecha")
        {
            Rigidbody flecha = other.GetComponent<Rigidbody>();
            flecha.isKinematic = true;
        }
    }
}
