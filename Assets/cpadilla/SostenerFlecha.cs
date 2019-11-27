using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SostenerFlecha : MonoBehaviour
{
    Rigidbody rigibody;
    private void OnTriggerEnter(Collider other) {

        rigibody=other.GetComponent<Rigidbody>();
        rigibody.isKinematic=true;
        rigibody.useGravity=false;

    }
}
