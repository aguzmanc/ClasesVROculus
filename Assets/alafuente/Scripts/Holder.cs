using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool manoCerrada;

    public Bow arco;


    void Start() {
        manoCerrada = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();//

        if(manoCerrada && arco != null){// && cambio) {//){//
            arco.Agarrar(transform);
        }

        if(!manoCerrada && arco != null){// && cambio){//){//
            arco.Soltar();
        }
    }




    //*
    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            manoCerrada = true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            manoCerrada = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }
    //*/



    void OnTriggerEnter(Collider otro) {
        Debug.Log("Trigger");
        Bow arcoDetectado = otro.GetComponent<Bow>();

        if(arcoDetectado!=null) {
            arco = arcoDetectado;
            arco.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        Bow arcoDetectado = otro.GetComponent<Bow>();
        if(arcoDetectado!=null) {
            arco.DejarDeTocar();
            arco = null;
        }
    }
}
