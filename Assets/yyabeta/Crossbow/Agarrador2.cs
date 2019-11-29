using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador2 : MonoBehaviour
{
   const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    public bool trigger;

    [Range(0f, 1f)]
    public float agarre;

    public bool estaAgarrando;

    public Ballesta ballesta;

    void Start() {
        estaAgarrando = false;
    }


    void Update()
    {
        bool cambio = UpdateNivelAgarre();

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.LTouch) && ballesta != null)
        {
            ballesta.DisparaFlecha(100);
        }

        if(estaAgarrando && ballesta != null && cambio) {
            ballesta.Agarrar(transform);
            
        }
        if(estaAgarrando==false && cambio && ballesta!=null){
            ballesta.Soltar();
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
        Ballesta ballestaAgarrada = otro.GetComponent<Ballesta>();

        if(ballestaAgarrada!=null) {
            ballesta = ballestaAgarrada;
            ballesta.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        Arco arcoAgarrado = otro.GetComponent<Arco>();
        if(arcoAgarrado!=null) {
            ballesta.DejarDeTocar();
            ballesta = null;
        }
    }
}
