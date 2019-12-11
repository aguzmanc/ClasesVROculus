﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bate : MonoBehaviour
{
    public Renderer render;
    Rigidbody body;
    public Material matSuelto;
    public Material matTocado;
    public Material matAgarrado;
    public Material matNoGolpear;
    
    void Start()
    {
        body = transform.parent.GetComponent<Rigidbody>();
        //render = GetComponent<Renderer>();
        render.material= matSuelto;
    }
    public void Tocar(){
        render.material = matTocado;
    }
    public void DejarTocar(){
        render.material =matSuelto;
    }
    public void NoGolpear(){
        render.material =matNoGolpear;
    }
    public void Golpear(){
        render.material =matAgarrado;
    }
    public void Soltar(){
        transform.parent.parent = null;
        body.isKinematic = false;
        render.material = matTocado;
    }
    public void Agarrar(Transform agarrador){
        render.material =matAgarrado;
        body.isKinematic = true;
        transform.parent.parent = agarrador;
        transform.parent.localPosition = new Vector3(0,1.5f,0);
        transform.parent.localRotation = Quaternion.identity;


    }
    void OnTriggerEnter(Collider other) {
        if (other.tag=="piso")
        {
            body.isKinematic = true;
            transform.position = new Vector3(0.736f,1.398f,0.053f);
            transform.rotation = Quaternion.identity;
        }
    }
}
