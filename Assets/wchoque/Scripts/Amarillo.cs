using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amarillo : MonoBehaviour
{
    
    Bala bala;
    public Puntuacion puntuacion;
    public int valorAmarillo;
    // Start is called before the first frame update
    void Start()
    {
        valorAmarillo = 20;
        puntuacion = GameObject.FindWithTag("puntuacion").GetComponent<Puntuacion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro azul");
        if(other.tag == "bala"){
           bala= other.transform.GetComponent<Bala>();
           if(!bala.ganoPuntos){
               bala.ganoPuntos=true;
               puntuacion.puntos+=valorAmarillo;
               
           }
            
        }
    }
}
