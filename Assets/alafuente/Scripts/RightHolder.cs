using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHolder : MonoBehaviour
{

    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool manoCerrada;

    public BowString cuerda;

    private bool agarrandoCuerda;


    void Start() {

        manoCerrada = false;

        agarrandoCuerda = false;
    }


    void Update()
    {
        //bool cambio = UpdateNivelAgarre();
        
        if(manoCerrada && cuerda != null ){// && cambio) {
            cuerda.Agarrar(transform);
            agarrandoCuerda = true;
        }

        if(!manoCerrada && cuerda != null ){// && cambio ){
            cuerda.Soltar();
            agarrandoCuerda = false;
        }
        
    }



/*
    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
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
*/


    void OnTriggerEnter(Collider otro) {
        BowString cuerdaDetectada = otro.GetComponent<BowString>();

        if(cuerdaDetectada!=null) {
            Debug.Log("tocar");
            cuerda = cuerdaDetectada;
            cuerda.Tocar();
        }
    }
    
    void OnTriggerExit(Collider otro) {
        BowString cuerdaDetectada = otro.GetComponent<BowString>();
        if(cuerdaDetectada!=null && !agarrandoCuerda) {
            Debug.Log("dejar de tocar");
            cuerda.DejarDeTocar();
            cuerda = null;
        }
    }
    
}
