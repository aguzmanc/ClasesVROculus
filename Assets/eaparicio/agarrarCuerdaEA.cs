using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarCuerdaEA : MonoBehaviour
{
    public float LIMITE_AGARRE=0.7F;
    public float LIMITE_SOLTAR=0.3F;
    cuerdaEA cuerdaEA;
    [Range(0f, 1f)]
    public float agarreCuerda;
    public bool estaAgarrado;

    [Range(0f, 1f)]
    public float actu;
    void Start()
    {
        estaAgarrado=false;
    }

    bool cambio;
    void Update()
    {
        cambio = UpdateAgarre();

        if (estaAgarrado && cuerdaEA != null && cambio)
        {
            cuerdaEA.Agarrar();
        }
        if(!estaAgarrado && cambio && cuerdaEA!=null){
            cuerdaEA.Soltar();
        }
    }

    bool UpdateAgarre(){
        // float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        // bool limitePasado=false;
        // if (agarreCuerda<LIMITE_AGARRE && agarreCuerda>=LIMITE_AGARRE)
        // {
        //     estaAgarrado=true;
        //     limitePasado=true;
        // }
        // if (agarreCuerda>LIMITE_SOLTAR && actual <=LIMITE_SOLTAR)
        // {
        //     estaAgarrado=false;
        //     limitePasado=true;
        // }
        // agarreCuerda=actual;
        // return limitePasado;




        bool limitePasado=false;
        if (agarreCuerda<LIMITE_AGARRE && agarreCuerda>=LIMITE_AGARRE)
        {
            estaAgarrado=true;
            limitePasado=true;
        }
        if (agarreCuerda>LIMITE_SOLTAR && actu <=LIMITE_SOLTAR)
        {
            estaAgarrado=false;
            limitePasado=true;
        }
        agarreCuerda=actu;
        return limitePasado;

    }

     private void OnTriggerEnter(Collider otro) {
        cuerdaEA = otro.GetComponent<cuerdaEA>();
        if (otro.tag=="cuerda")
        {
            cuerdaEA.Tocar();
        }
    }

    void OnTriggerExit(Collider otro)
    {
        cuerdaEA = otro.GetComponent<cuerdaEA>();
        if (otro.tag=="cuerda")
        {
            cuerdaEA.DejarTocar();
        }
    }
}
