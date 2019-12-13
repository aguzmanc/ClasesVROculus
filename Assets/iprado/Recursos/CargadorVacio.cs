using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorVacio : MonoBehaviour
{
    Rigidbody body;
    public float fuerza= 10f;
    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody>();
        body.AddForce(new Vector3(0,0,fuerza),ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
