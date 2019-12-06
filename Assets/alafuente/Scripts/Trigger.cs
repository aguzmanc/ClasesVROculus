using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject SM_Arrow;
    public float strength = 0;
    public Renderer rend;    
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto; 

    public bool apretado = false;


    private bool cargado;


    void Start()
    {

        rend.material = materialSuelto;
        SM_Arrow = GameObject.Find("SM_Arrow");
    }



    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public void Apretar() 
    {
        if(!apretado)
        {
            GameObject arrow = Instantiate(SM_Arrow);
            arrow.transform.position = transform.position;
            arrow.transform.Rotate(-90,0,0); 
            arrow.transform.Translate(0.07f,0,0);
            strength=50;   
            Rigidbody body = arrow.GetComponent<Rigidbody>();

            body.AddForce(transform.forward * strength, ForceMode.Impulse);
        }

        apretado = true;
    }
}
