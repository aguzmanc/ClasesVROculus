using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerda : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Cuerda"){
            Cuerda cuerda = other.GetComponent<Cuerda>();
            cuerda.Tocar();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Cuerda"){
            Cuerda cuerda = other.GetComponent<Cuerda>();
            cuerda.DejarDeTocar();
        }
    }
}
