﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradoE : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool estaAgarrando;

    public ArcoE arco;


    void Start() {
        estaAgarrando = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();

        if(estaAgarrando && arco != null && cambio) {
            arco.Agarrar(transform);
        }

        if(estaAgarrando==false && cambio && arco!=null){
            arco.Soltar();
        }
    }

    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            estaAgarrando = true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            estaAgarrando = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }

    void OnTriggerEnter(Collider c) {
        ArcoE arcoAgarrado = c.GetComponent<ArcoE>();
        Debug.Log(arcoAgarrado.name);

        if(arcoAgarrado!=null) {
            arco = arcoAgarrado;
            arco.Tocar();
        }
    }

    void OnTriggerExit(Collider c) {
        ArcoE arcoAgarrado = c.GetComponent<ArcoE>();
        if(arcoAgarrado!=null) {
            arco.DejarDeTocar();
            arco = null;
        }
    }
}

