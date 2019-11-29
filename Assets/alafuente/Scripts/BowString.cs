using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowString : MonoBehaviour
{  
    public GameObject SM_Arrow;
    public float strength = 0;
    public float distancia;
    public Renderer rend;    
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto; 

    public Transform baseCuerda;
    public Transform mano;

    private bool cargado;


    void Start()
    {
        distancia = 0;
        cargado = false;

        baseCuerda = transform.parent; //
        rend.material = materialSuelto;
        SM_Arrow = GameObject.Find("SM_Arrow");
    }



    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }


    public void Agarrar(Transform agarrador) 
    {
        rend.material = materialAgarrado;
        mano = agarrador;
    }
    void Update()
    {
        if(mano != null)
        {
            distancia = Vector3.Distance(baseCuerda.position, mano.position);
            Debug.Log(distancia);
            Debug.DrawLine(baseCuerda.position, mano.position, Color.green);
            if(distancia < 0.5f)
            {
                transform.localPosition = new Vector3(0,0,distancia*10);
                Debug.Log("Desplazando");
            }//else
            //{
            //    cargado = true;
            //}
            if(distancia > 0.1f)
            {
                cargado = true;
            }
        }else
        {
            distancia = 0;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }


    public void Soltar() {
        if (cargado)
        {
            GameObject arrow = Instantiate(SM_Arrow);
            arrow.transform.position = baseCuerda.transform.position;
            arrow.transform.Rotate(-90,0,0); 
            arrow.transform.Translate(0.07f,0,0);
            strength=distancia*100;//(50);   
            Rigidbody body = arrow.GetComponent<Rigidbody>();
            body.AddForce(baseCuerda.transform.forward * -1 * strength, ForceMode.Impulse);
        }  
        mano = null;
        cargado = false;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }




}
