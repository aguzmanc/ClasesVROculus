using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaIP : MonoBehaviour
{
    public float fuerza=140;
    
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody>();
        body.isKinematic=true;
        body.useGravity=false;
    }

    void Update()
    {

    }
    public void Agarrar()
    {


    }
    public void Disparar(float distancia)
    {   
        body.isKinematic=false;
        body.useGravity=true;
        body.AddRelativeForce(new Vector3(0,0,fuerza*distancia),ForceMode.Impulse);

    }
}
