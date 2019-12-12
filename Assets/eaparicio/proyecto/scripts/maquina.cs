using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maquina : MonoBehaviour
{
    public AudioClip golpeMaquina;
    public puntaje puntaje;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.name=="bate")
        {
            other.GetComponentInChildren<bate>().NoGolpear();
            if (other.GetComponentInChildren<bate>().golpear)
            {
                transform.GetComponent<AudioSource>().Play();
                puntaje.GolpeEjecutado(false);
            }
            other.GetComponentInChildren<bate>().golpear=false;
        }
    }

}
