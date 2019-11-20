using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcoea : MonoBehaviour
{
    Renderer render;
    Rigidbody body;
    public Material matSuelto;
    public Material matTocado;
    public Material matAgarrado;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        render.material= matSuelto;
    }
    public void Tocar(){
        render.material = matTocado;
    }
    public void DejarTocar(){
        render.material =matSuelto;
    }
    public void Agarrar(Transform agarrador){
        render.material =matAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;


        //Para que la mano se ubique al centro del arco
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void Soltar(){
        transform.parent = null;
        body.isKinematic = false;
        render.material = matTocado;
    }
}
