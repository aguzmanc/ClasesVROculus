using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        /*
        if (other.tag == "Cuerda")
        {
            Cuerda cuerdab = other.GetComponent<Cuerda>();
            cuerdab.Tocar();
        }*/
    }

    private void OnTriggerExit(Collider other) {
        /*
           if (other.tag == "Cuerda")
        {
            Cuerda cuerdab = other.GetComponent<Cuerda>();
            cuerdab.DejarDeTocar();
        }*/
    }
}
