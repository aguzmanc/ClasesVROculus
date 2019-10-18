using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCubo : MonoBehaviour
{
    public Transform r;
    public Transform l;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        transform.position = Vector3.Lerp(r.position, l.position, 0.1f);
    }
}
