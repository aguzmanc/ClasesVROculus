using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorC : MonoBehaviour
{
     const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;
    bool cambio;
    public bool estaAgarrando;
    float actual;
    public ArcoC arco;


    void Start() {
        estaAgarrando = false;
    }


    void Update()
    {
        cambio = UpdateNivelAgarre();
        cambio=true;
        if(estaAgarrando && arco != null && cambio) {
            arco.Agarrar(transform);
        }

        if(estaAgarrando==false && cambio && arco!=null){
            arco.Soltar();
        }
    }




    bool UpdateNivelAgarre(){
        actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
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



    void OnTriggerEnter(Collider otro) {
        if (otro.tag=="ArcoC")
        {
          ArcoC arcoAgarrado = otro.GetComponent<ArcoC>();

            if(arcoAgarrado!=null) 
            {
                arco = arcoAgarrado;
                arco.Tocar();
            }   
        }
    }


    void OnTriggerExit(Collider otro) {
        ArcoC arcoAgarrado = otro.GetComponent<ArcoC>();
        if(arcoAgarrado!=null) {
            arco.DejarDeTocar();
            arco = null;
        }
    }
}
