﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerda : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;
    public bool estaAgarrando;
    public Transform transformleft;

    public float distancia;
    public bool tocando;
    public Transform pivotCuerda;
    public Cuerda cuerda;
   
    public GameObject flecha;
   

    void Start()
    {
        tocando = false;
        estaAgarrando = false;
    }

    void Update()
    {
        if (estaAgarrando)
        {
            distancia = Vector3.Distance(transform.position, pivotCuerda.position);
            distancia = Mathf.Max(0f, distancia);
            distancia = Mathf.Min(0.3f, distancia);
            Debug.DrawLine(transform.position, pivotCuerda.position, Color.green);
           
        }
        else
        {
           
            distancia = 0;
        }
       
         
        
        if (cuerda != null)
            cuerda.transform.localPosition = new Vector3(0, 0, distancia);






        bool cambio = UpdateNivelAgarre();

        if (estaAgarrando && cambio)
        {
            if (cuerda != null)
                cuerda.Agarrar();
        }

        if (estaAgarrando == false && cuerda != null)
        {
            if (cuerda != null)
            {
                cuerda.Soltar();
               
            }
              
           
        }

    }


    bool UpdateNivelAgarre()
    {
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool limiteTraspasado = false;

        if (agarre < LIMITE_AGARRE && actual >= LIMITE_AGARRE)
        {
            estaAgarrando = true;
            limiteTraspasado = true;
        }

        if (agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
        {
            if (estaAgarrando)
            {

                GameObject createdBullet = Instantiate(flecha);
                createdBullet.transform.position = transformleft.position;
                 createdBullet.transform.rotation = transformleft.rotation;
                Rigidbody body = createdBullet.GetComponent<Rigidbody>();
                //body.AddForce(0,0,distancia*50f ,ForceMode.Impulse);
                body.velocity = transformleft.forward * distancia * 50f;
            }
            estaAgarrando = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cuerda")
        {
            cuerda = other.GetComponent<Cuerda>();
            cuerda.Tocar();
            tocando = true;
            pivotCuerda = cuerda.transform.parent;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cuerda")
        {
            cuerda = other.GetComponent<Cuerda>();
            cuerda.DejarDeTocar();
            tocando = false;
        }
    }
}

