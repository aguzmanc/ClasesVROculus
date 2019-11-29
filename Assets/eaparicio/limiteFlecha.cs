using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limiteFlecha : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (other.name=="derecha")
        {
            other.GetComponent<agarrarCuerdaEA>().LimiteBallestaPasado();
        }
    }
}
