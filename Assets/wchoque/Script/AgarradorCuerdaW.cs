using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdaW : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Cuerda"){
            Debug.Log("Tocar Cuerda");
           /*  Cuerda cuerda =other.GetComponent<Cuerda>();
            cuerda.Tocar();*/
        }
    }
    private void OnTriggerExit(Collider other) {
         if(other.tag=="Cuerda"){
             Debug.Log("Dejar de Tocar Cuerda");
           /* Cuerda cuerda =other.GetComponent<Cuerda>();
            cuerda.DejarTocar();*/
        }
    }
}
