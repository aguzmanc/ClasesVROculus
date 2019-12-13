using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaRoja : MonoBehaviour
{
    public bool disparo;
    Rigidbody rb;
    void Start()
    {
        disparo=false;
        rb= this.transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(disparo)
        {
            rb.AddForce(transform.forward * 5);
        }
    }

    public void flechaLanzada()
    {
          transform.parent=null;
          rb.isKinematic=false;
          disparo=true;
    }
}
