﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag=="circulo")
        {
        GetComponent<Rigidbody>().useGravity=false;
        GetComponent<Rigidbody>().isKinematic=true;
        
        }
    }
}
