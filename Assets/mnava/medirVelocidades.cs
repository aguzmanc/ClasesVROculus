using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medirVelocidades : MonoBehaviour
{
    Rigidbody cuerpo;
    // Start is called before the first frame update
    void Start()
    {
        cuerpo=transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( cuerpo.velocity);
    }
}
