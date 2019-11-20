using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTool : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool isTaken;

    public ArcoIP arco;

    void Start() {
        isTaken = false;
    }

    void Update()
    {
        bool cambio = UpdateNivelAgarre();

        if(isTaken && arco != null && cambio) {
            arco.Agarrar(transform);
        }

        if(isTaken==false && cambio && arco!=null){
            arco.Soltar();
        }
    }

    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            isTaken = true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            isTaken = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }

    void OnTriggerEnter(Collider otro) {
        ArcoIP arcoAgarrado = otro.GetComponent<ArcoIP>();

        if(arcoAgarrado!=null) {
            arco = arcoAgarrado;
            arco.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        ArcoIP arcoAgarrado = otro.GetComponent<ArcoIP>();
        if(arcoAgarrado!=null) {
            arco.DejarDeTocar();
            arco = null;
        }
    }
}
