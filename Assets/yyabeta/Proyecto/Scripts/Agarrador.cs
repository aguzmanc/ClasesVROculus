using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    public OVRInput.Controller controller;

    [Range(0f, 1f)]
    public float agarre;

    public bool estaAgarrando;

    void Start() {
        estaAgarrando = false;
    }


    void Update()
    {
       
    }




    protected bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
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
}
