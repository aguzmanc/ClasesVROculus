using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RojoCabeza : MonoBehaviour
{
    
    Bala bala;
    public Puntuacion puntuacion;
    public int valorRojoCabeza;
    // Start is called before the first frame update
    void Start()
    {
        valorRojoCabeza= 30;
         puntuacion = GameObject.FindWithTag("puntuacion").GetComponent<Puntuacion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
      //  Debug.Log("Entro azul");
        if(other.tag == "bala"){
           bala= other.transform.GetComponent<Bala>();
           if(!bala.ganoPuntos){
               bala.ganoPuntos=true;
               puntuacion.puntos+=valorRojoCabeza;
               
           }
            
        }
    }
}
