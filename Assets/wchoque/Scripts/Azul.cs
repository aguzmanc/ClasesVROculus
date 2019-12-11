using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azul : MonoBehaviour
{
    Bala bala;
    public Puntuacion puntuacion;
    public int valorAzul;
    // Start is called before the first frame update
    void Start()
    {
        valorAzul = 5;
         puntuacion = GameObject.FindWithTag("puntuacion").GetComponent<Puntuacion>();
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
       // Debug.Log("Entro azul");
        if(other.tag == "bala"){
           bala= other.transform.GetComponent<Bala>();
           if(!bala.ganoPuntos){
               bala.ganoPuntos=true;
               puntuacion.puntos+=valorAzul;
               
           }
            
        }
    }
}
