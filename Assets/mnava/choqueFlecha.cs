﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choqueFlecha : MonoBehaviour
{
    
    fidicasFlecha feleCuer;
    // Start is called before the first frame update
    void Start()
    {
       feleCuer=transform.GetComponent<fidicasFlecha>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) {
       if(other.tag=="pared")
       {
           feleCuer.parar();
           Debug.Log("Si");
       }
        
    }
}
