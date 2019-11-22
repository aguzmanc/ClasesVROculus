using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fidicasFlecha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarK()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
        rb.isKinematic=false;
    }
    public void volverK()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
        rb.isKinematic=true;
    }
}
