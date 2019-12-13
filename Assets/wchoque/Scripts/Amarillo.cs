using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Amarillo : MonoBehaviour
{
    public TextMeshPro txtPunto;
    Bala bala;
    public Puntuacion puntuacion;
    public int valorAmarillo;
    // Start is called before the first frame update
    void Start()
    {
        valorAmarillo = 20;
        puntuacion = GameObject.FindWithTag("puntuacion").GetComponent<Puntuacion>();
         txtPunto = GameObject.Find("textPunto").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Entro azul");
        if(other.tag == "bala"){
           bala= other.transform.GetComponent<Bala>();
           if(!bala.ganoPuntos){
               bala.ganoPuntos=true;
               puntuacion.puntos+=valorAmarillo;
               if(txtPunto.gameObject.activeSelf){
                   //azul
                   //txtPunto.color = new Color32(0, 0, 255, 1);
                 //  txtPunto.color = new Color32(230, 255, 0, 1);
                   txtPunto.text = "Mas " + valorAmarillo + " puntos";
               }
               else{
                   txtPunto.gameObject.SetActive(true);
                 //   txtPunto.color = new Color32(230, 255, 0, 1);
                   txtPunto.text = "Mas " + valorAmarillo + " puntos";
               }
               
           }
            
        }
    }
}
