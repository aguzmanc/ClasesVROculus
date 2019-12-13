﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaRoja : MonoBehaviour
{
    public Renderer agarrador;
    Rigidbody cuerpo;
    public Material agarrado;
    public Material suelto;
     public Material tocado;
     public GameObject flecha;
     public Transform origenFlecha;
     bool cargada;
     public FlechaRoja flechaRoja;

    public bool Cargada()
    {
        return cargada;
    }

    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        flechaRoja = GameObject.FindObjectOfType<FlechaRoja>();
        agarrador.material=suelto;
        cargada=false;
    }
    
      public void tocar()
    {
        agarrador.material=tocado;
    }
    public void dejarTocar()
    {
        agarrador.material=suelto;
       
    }
      public void agarrar(Transform mano)
    {
        
        agarrador.material=agarrado;
      
        transform.parent=mano;
        cuerpo.isKinematic=true;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
      
    }   
     public void soltar()
    {
        agarrador.material=suelto;
        transform.parent=null;
        cuerpo.isKinematic=false;
    }
    public void disparar()
    {
      if(cargada)
      {
          flechaRoja.flechaLanzada();
          cargada=false;
      }
      
    }
    public void recargar()
    {
        if(!cargada)
        {
            GameObject newFlecha = (GameObject) Instantiate(flecha);
            cargada=true;
            newFlecha.transform.position = origenFlecha.position;
            newFlecha.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
