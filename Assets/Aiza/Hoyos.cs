﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoyos : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bola_Color")
        {
            Destroy(other.gameObject);
           
        }
    }
}
