using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquina : MonoBehaviour
{
    public puntaje puntaje;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.name=="bate")
        {
            other.GetComponentInChildren<bate>().NoGolpear();
            other.GetComponentInChildren<bate>().golpear=false;
            puntaje.GolpeEjecutado(false);
        }
    }

}
