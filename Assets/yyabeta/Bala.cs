using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Destroy(this.gameObject,3);
        GetComponent<Rigidbody>().AddForce(Vector3.forward*speed,ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
