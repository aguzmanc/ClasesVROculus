using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fidicasFlecha : MonoBehaviour
{
    public bool disparada;
    float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        disparada=false;
        fuerza=1;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(disparada)
        {
            Rigidbody cuerpo= transform.GetComponent<Rigidbody>();
            cuerpo.AddForce(transform.forward*(fuerza*-1));
            
        }
    }
    public void cambiarK()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
        rb.isKinematic=false;
        transform.parent=null;
        disparada=true;
         transform.localScale=Vector3.one;
    }
    public void volverK()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
        rb.isKinematic=true;
        disparada=false;
    }
    public void tp()
    {
         transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
       
    }
    public void darf(float distancia)
    {
        float porc=(distancia*100f)/1.6f;
        fuerza=(porc*20)/100;


    }
    public void parar()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
         rb.isKinematic=true;
        disparada=false;

    }
}
