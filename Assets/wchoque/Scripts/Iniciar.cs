using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Iniciar : MonoBehaviour
{
    public TextMeshPro txtIniciar;
     public CuadroTiempo tiempo;
    public bool dentroArea;
    float contador;
    // Start is called before the first frame update
    void Start()
    {
        dentroArea = false;
    }

    // Update is called once per frame
    void Update()
    {
            if(dentroArea){
            contador+=Time.deltaTime;
            
              
            if(contador >=5){
                if(tiempo.comenzoJuego==false){
                    txtIniciar.text ="Inicio Juego";
                    tiempo.comenzoJuego = true;
                    contador = 0;
                }
            }
            else{
                if(tiempo.comenzoJuego !=true)
                        txtIniciar.text = "Espere durante 3 segundos: seg= " + contador;    
            }
        }
    }
        /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.name=="indicadorIzquierda"){
            dentroArea = true;
            txtIniciar.gameObject.SetActive(true);
              txtIniciar.text = "Espere durante 3 segundos: seg= " ;
        }
        
    }
     /// <summary>
     /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
     /// </summary>
     /// <param name="other">The other Collider involved in this collision.</param>
     void OnTriggerExit(Collider other)
     {
         
        if(other.name=="indicadorIzquierda"){
            dentroArea = false;
            txtIniciar.gameObject.SetActive(false);
        }
        
         
     }
}
