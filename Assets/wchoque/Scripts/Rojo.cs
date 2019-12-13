﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Rojo : MonoBehaviour
{
    public TextMeshPro txtPunto;
    Bala bala;
    public Puntuacion puntuacion;
    public int valorRojo;
    // Start is called before the first frame update
    void Start()
    {
        valorRojo =10;
        puntuacion = GameObject.FindWithTag("puntuacion").GetComponent<Puntuacion>();
         txtPunto = GameObject.Find("textPunto").GetComponent<TextMeshPro>();
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
               puntuacion.puntos+=valorRojo;
                if(txtPunto.gameObject.activeSelf){
                   //azul
                   //txtPunto.color = new Color32(0, 0, 255, 1);
                 //  txtPunto.color = new Color32(255, 0, 0, 1);
                   txtPunto.text = "Mas " + valorRojo + " puntos";
               }
               else{
                   txtPunto.gameObject.SetActive(true);
                   // txtPunto.color = new Color32(255, 0, 0, 1);
                   txtPunto.text = "Mas " + valorRojo + " puntos";
               }
           }
            
        }
    }
}
