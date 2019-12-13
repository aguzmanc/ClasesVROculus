using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Azul : MonoBehaviour
{
    public TextMeshPro txtPunto;
    Bala bala;
    public Puntuacion puntuacion;
    public int valorAzul;
    // Start is called before the first frame update
    void Start()
    {
        valorAzul = 5;
         puntuacion = GameObject.FindWithTag("puntuacion").GetComponent<Puntuacion>();
         txtPunto = GameObject.Find("textPunto").GetComponent<TextMeshPro>();
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
                if(txtPunto.gameObject.activeSelf){
                   //azul
                //   txtPunto.color = new Color32(0, 0, 255, 1);
                  // txtPunto.color = new Color32(255, 0, 0, 1);
                   txtPunto.text = "Mas " + valorAzul + " puntos";
               }
               else{
                   txtPunto.gameObject.SetActive(true);
                  //  txtPunto.color = new Color32(0, 0, 255, 1);
                   txtPunto.text = "Mas " + valorAzul + " puntos";
               }
           }
            
        }
    }
}
