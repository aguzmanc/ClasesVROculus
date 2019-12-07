using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianaDerecha : MonoBehaviour
{
    int numero = 30;

    void Update()
    {
        transform.Translate(Vector3.left / numero);
    }
}
