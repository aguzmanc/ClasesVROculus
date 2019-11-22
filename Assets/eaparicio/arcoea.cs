using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcoea : MonoBehaviour
{
    public Renderer render;
    Rigidbody body;
    public GameObject cuerda;
    public Material matSuelto;
    public Material matTocado;
    public Material matAgarrado;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //render = GetComponent<Renderer>();
        render.material= matSuelto;
        cuerda  = transform.Find("cuerda").gameObject;
        cuerda.SetActive(false);
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

        cuerda.SetActive(true);

        //Para que la mano se ubique al centro del arco
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void Soltar(){
        cuerda.SetActive(false);
        transform.parent = null;
        body.isKinematic = false;
        render.material = matTocado;
    }
}
