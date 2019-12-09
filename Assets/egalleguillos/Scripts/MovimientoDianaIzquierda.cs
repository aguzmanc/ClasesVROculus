using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianaIzquierda : MonoBehaviour
{
    int numero = 10;

    void Update()
    {
        transform.Translate(Vector3.up / numero);
    }
}
