using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianaCentro : MonoBehaviour
{
    int numero = 10;

    void Update()
    {
        transform.Translate(Vector3.right / numero);
    }
}
