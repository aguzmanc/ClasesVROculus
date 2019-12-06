using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianaIzquierda : MonoBehaviour
{
    GameObject dianaRojaIzq;
    GameObject dianaVerdeIzq;
    GameObject dianaAmarillaIzq;
    void Start()
    {
        dianaAmarillaIzq = transform.GetChild(0).gameObject;
        dianaRojaIzq = transform.GetChild(1).gameObject;
        dianaVerdeIzq = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        
    }
}
