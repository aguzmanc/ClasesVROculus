﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaW : MonoBehaviour
{
    

      public Renderer rend;
      public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSoltado;

 
    void Start()
    {
      
    }

    void Update()
    {
     
    }
      public void Tocar(){
        rend.material = materialTocado;
        Debug.Log("toco");
    }
    public void DejarTocar(){
        rend.material = materialSoltado;
    }
    public void Agarrar(){
        rend.material = materialAgarrado;
      //  body.isKinematic=true;
       
        //transform.localPosition=Vector3.zero;
       // transform.localRotation = Quaternion.identity;
    }
    public void Soltar(){
      
        rend.material =materialTocado;
      //  body.isKinematic =false;
    }
}
