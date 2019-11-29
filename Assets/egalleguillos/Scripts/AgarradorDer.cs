using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorDer : MonoBehaviour
{
    float distancia;



    void Update() {
        distancia = Vector3.Distance(transform.position, transform.position);
    }
}
