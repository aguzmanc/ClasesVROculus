using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrar : MonoBehaviour
{
    public float LIMITE_AGARRE=0.7F;
    public float LIMITE_SOLTAR=0.3F;
    public bool estaAgarrado;



     [Range(0f, 1f)]
    public float agarre;
     [Range(0f, 1f)]
    public float actu;
    public arcoea arc;
    public ballestaea ballesta;
    void Start()
    {
        estaAgarrado=false;   
    }

    bool cambio;
    void Update()
    {
        cambio = UpdateAgarre();
        if (estaAgarrado && cambio)
        {
            if (arc!=null)
                arc.Agarrar(transform);
            if (ballesta!=null)
                ballesta.Agarrar(transform);
        }
        if(!estaAgarrado && cambio){
            if (arc!=null)
                arc.Soltar();
            if (ballesta!=null)
                ballesta.Soltar();
        }
    }

    bool UpdateAgarre(){

        //PRUEBAS PC
        // float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        // bool limitePasado=false;
        // if (agarre<LIMITE_AGARRE && actu>=LIMITE_AGARRE)
        // {
        //     estaAgarrado=true;
        //     limitePasado=true;
        // }
        // if (agarre>LIMITE_SOLTAR && actu <=LIMITE_SOLTAR)
        // {
        //     estaAgarrado=false;
        //     limitePasado=true;
        // }
        // agarre=actu;
        // return limitePasado;



        //PRUEBAS VR
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        bool limitePasado=false;
        if (agarre<LIMITE_AGARRE && actual>=LIMITE_AGARRE)
        {
            estaAgarrado=true;
            limitePasado=true;
        }
        if (agarre>LIMITE_SOLTAR && actual <=LIMITE_SOLTAR)
        {
            estaAgarrado=false;
            limitePasado=true;
        }
        agarre=actual;
        return limitePasado;
    }
    private void OnTriggerEnter(Collider otro) {
        
        if (otro.tag=="ballesta")
        {
            ballestaea ball = otro.GetComponent<ballestaea>();
            if (ball!=null)
            {
                ballesta = ball;
                ballesta.Tocar();
            }
        }
       if (otro.tag=="arco")
       {
            arcoea arcoAgarrado = otro.GetComponent<arcoea>();
            if (arcoAgarrado!=null)
            {
                arc = arcoAgarrado;
                arcoAgarrado.Tocar();
            }
        }
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.tag=="ballesta")
        {
             ballestaea ball = otro.GetComponent<ballestaea>();
            if (ball!=null)
            {
                ballesta = ball;
                ballesta.DejarTocar();
            }
        }
        else{
            arcoea arcoAgarrado = otro.GetComponent<arcoea>();
            if (arcoAgarrado!=null)
            {
                arc=null;
                arcoAgarrado.DejarTocar();
            }
        }
        
        
    }
}
