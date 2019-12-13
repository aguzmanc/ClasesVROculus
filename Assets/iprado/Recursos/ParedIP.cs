using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedIP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="flecha")
        {
            Rigidbody body = other.GetComponent<Rigidbody>();
            body.isKinematic=true;
        }
    }
}
