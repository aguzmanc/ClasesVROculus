using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Pared")
        {
            rigidbody.constraints=RigidbodyConstraints.FreezeAll;
        }
    }
}
