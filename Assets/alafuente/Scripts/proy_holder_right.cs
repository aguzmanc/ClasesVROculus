using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proy_holder_right : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool manoCerrada;

    public proy_animal animal;


    void Start() {
        manoCerrada = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();//

        if(manoCerrada && animal != null && cambio){//){//
            animal.Agarrar(transform);
        }

        if(!manoCerrada && animal != null && cambio){//){//
            animal.Soltar();
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
        Debug.Log("Trigger");
        proy_animal animalDetectado = otro.GetComponent<proy_animal>();

        if(animalDetectado!=null) {
            animal = animalDetectado;
            animal.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        proy_animal animalDetectado = otro.GetComponent<proy_animal>();
        if(animalDetectado!=null) {
            animal.DejarDeTocar();
            animal = null;
        }
    }
}
