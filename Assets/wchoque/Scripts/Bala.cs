﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Physics.Raycast (transform.position, transform.forward, 10)){
        Debug.DrawRay (transform.position, transform.forward * 10, Color.yellow );
            Debug.Log ("Did Hit");
        }
            
        transform.position += transform.forward * 5 * Time.deltaTime;
    }
}
