using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Reiniciar : MonoBehaviour
{
   public  TextMeshPro txtReiniciar;
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
                txtReiniciar.text = "Reinicio";
                SceneManager.LoadScene("proyectoPistola");

            }
            else{
                txtReiniciar.text = "Espere durante 3 segundos: seg= " + contador;
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
            txtReiniciar.gameObject.SetActive(true);
            txtReiniciar.text = "Espere 3 segundos: seg= " ;
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
            txtReiniciar.gameObject.SetActive(false);
        }
        
         
     }
}
