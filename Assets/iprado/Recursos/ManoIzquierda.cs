using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoIzquierda : MonoBehaviour
{

    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    public float agarre;

    public bool grabActivado=false;

    public CargadorIP cargador;

    bool agarrado=false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool cambio = UpdateNivelAgarre();

        if(grabActivado && cargador != null && cambio) {
            cargador.Agarrar(transform);
            agarrado=true;
        }

        if(grabActivado==false && cambio && cargador!=null){
            cargador.Soltar();
            agarrado=false;
        }
       
    }

    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.RTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            grabActivado=true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            grabActivado=false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }

     void OnTriggerEnter(Collider otro) {
        CargadorIP cargadorAgarrado = otro.GetComponent<CargadorIP>();
        if(cargadorAgarrado!=null) {
            cargador = cargadorAgarrado;
            //cargador.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
         CargadorIP cargadorAgarrado = otro.GetComponent<CargadorIP>();
        if(cargadorAgarrado!=null) {
            cargador = null;
            // cargador.DejarDeTocar();
        }
    }
}
