using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool estaAgarrando;

    public Arco arco;

    void Start() {
        estaAgarrando = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();

        if(estaAgarrando && arco != null && cambio) {
            arco.Agarrar(transform);
            GetComponent<SphereCollider>().enabled=false;
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if(estaAgarrando==false && cambio && arco!=null){
            arco.Soltar();
            GetComponent<SphereCollider>().enabled=true;
            transform.GetChild(0).gameObject.SetActive(false);
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



    void OnTriggerEnter(Collider otro) {
        Arco arcoAgarrado = otro.GetComponent<Arco>();

        if(arcoAgarrado!=null) {
            arco = arcoAgarrado;
            arco.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        Arco arcoAgarrado = otro.GetComponent<Arco>();
        if(arcoAgarrado!=null) {
            arco.DejarDeTocar();
            arco = null;
        }
    }
}
