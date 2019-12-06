using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHolder : MonoBehaviour
{    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool manoCerrada;

    public Trigger gatillo;


    void Start() {

        manoCerrada = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();//
        
        if(manoCerrada && gatillo != null && cambio){//){//
            gatillo.Apretar();
        }

        if(!manoCerrada && gatillo != null && cambio){//){//
            gatillo.apretado = false;
        }
        
    }



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

    void OnTriggerEnter(Collider otro) {
        Trigger gatilloDetectado = otro.GetComponent<Trigger>();

        if(gatilloDetectado!=null) {
            Debug.Log("tocar");
            gatillo = gatilloDetectado;
            gatillo.Tocar();
        }
    }
    
    void OnTriggerExit(Collider otro) {
        Trigger gatilloDetectado = otro.GetComponent<Trigger>();
        if(gatilloDetectado!=null) {
            Debug.Log("dejar de tocar");
            gatillo.DejarDeTocar();
            gatillo = null;
        }
    }
}
