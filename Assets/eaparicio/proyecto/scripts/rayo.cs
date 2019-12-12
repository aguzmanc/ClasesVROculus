using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        bool choca = Physics.Raycast(transform.position, transform.forward,  out hit);
        if (choca)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawRay(transform.position, 6f*transform.forward, Color.green);
            if (hit.collider.name== "zona_martillo")
            {
                Debug.DrawRay(transform.position, 6f*transform.forward, Color.blue);
            }
            else
            {
                Debug.DrawRay(transform.position, 6f*transform.forward, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, 6f*transform.forward, Color.yellow);
        }

    }
}
