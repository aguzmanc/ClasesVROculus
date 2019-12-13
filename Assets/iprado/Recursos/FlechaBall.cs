using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaBall : MonoBehaviour
{
    public float fuerza=100;
    
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
        body=GetComponent<Rigidbody>();
        body.isKinematic=false;
        body.useGravity=true;
        body.AddRelativeForce(new Vector3(0,0,fuerza),ForceMode.Impulse);
    }
}
