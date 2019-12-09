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
    bool mantenerAgarrado;

    public ObjetoAgarrable objetoAgarrable;

    void Start() {
        estaAgarrando = false;
    }


    void Update()
    {
       bool cambio = UpdateNivelAgarre();

            if (objetoAgarrable != null && objetoAgarrable is Arma && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,controller))
            {
                Arma a = (Arma)objetoAgarrable;
                a.Disparar();
            }
        if(estaAgarrando && objetoAgarrable != null && cambio) {
            objetoAgarrable.Agarrar(transform);
            if(objetoAgarrable is Recargador){
                mantenerAgarrado=true;
            }
        }

        if(estaAgarrando==false && cambio && objetoAgarrable!=null){
            if(objetoAgarrable is Recargador && mantenerAgarrado){
                mantenerAgarrado=false;
                objetoAgarrable.Soltar();
                objetoAgarrable=null;
            }
            else
            {
                objetoAgarrable.Soltar();
            }
            
        }
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

    void OnTriggerEnter(Collider otro) {
        ObjetoAgarrable obj = otro.GetComponent<ObjetoAgarrable>();

        if(obj!=null&&objetoAgarrable==null) {
            objetoAgarrable = obj;
            objetoAgarrable.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        ObjetoAgarrable obj = otro.GetComponent<ObjetoAgarrable>();
        if(obj!=null&&objetoAgarrable==obj) {
            objetoAgarrable.DejarDeTocar();
            objetoAgarrable = null;
        }
    }
}
