using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bate : MonoBehaviour
{
    public Renderer render;
    Rigidbody body;
    public Material matSuelto;
    public Material matTocado;
    public Material matAgarrado;
    
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
    public void Agarrar(Transform agarrador){
        render.material =matAgarrado;
        //body.isKinematic = true;
        transform.parent = agarrador;


    }
    public void Soltar(){
        transform.parent = null;
        //body.isKinematic = false;
        render.material = matTocado;
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
