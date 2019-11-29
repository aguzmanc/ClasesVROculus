using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHolder : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool manoCerrada;

    public Crossbow ballesta;


    void Start() {
        manoCerrada = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();//

        if(manoCerrada && ballesta != null && cambio){//){//
            ballesta.Agarrar(transform);
        }

        if(!manoCerrada && ballesta != null && cambio){//){//
            ballesta.Soltar();
        }
    }




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



    void OnTriggerEnter(Collider otro) {
        Debug.Log("Trigger");
        Crossbow ballestaDetectado = otro.GetComponent<Crossbow>();

        if(ballestaDetectado!=null) {
            ballesta = ballestaDetectado;
            ballesta.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        Crossbow ballestaDetectado = otro.GetComponent<Crossbow>();
        if(ballestaDetectado!=null) {
            ballesta.DejarDeTocar();
            ballesta = null;
        }
    }
}
