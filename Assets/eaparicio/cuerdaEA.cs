using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuerdaEA : MonoBehaviour
{
    public Renderer render;
    Rigidbody body;
    public Material matSuelto;
    public Material matTocado;
    public Material matAgarrado;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        render.material= matSuelto;
    }
    public void Tocar(){
        render.material = matTocado;
    }
    public void DejarTocar(){
        render.material =matSuelto;
    }
    public void Agarrar(){
        render.material =matAgarrado;
        body.isKinematic = true;
    }
    public void Soltar(){
        render.material =matSuelto;
    }
}
