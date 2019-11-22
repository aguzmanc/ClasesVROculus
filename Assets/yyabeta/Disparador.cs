using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool estaAgarrando;
    bool tocandoCuarda;
    bool mantenerAgarrado;


    public Arco arco;

    public Transform hand;
private void Update() {
     bool cambio = UpdateNivelAgarre();
<<<<<<< HEAD
    if(estaAgarrando)
=======
    if(estaAgarrando&&tocandoCuarda)
>>>>>>> 0453b461cdc1a7772f469d8bed4000a7c0729dee
    {
        mantenerAgarrado=true;
        arco.MoverCuerda(transform);
    }
<<<<<<< HEAD
    if(estaAgarrando==false )
=======
    if(estaAgarrando==false && mantenerAgarrado)
>>>>>>> 0453b461cdc1a7772f469d8bed4000a7c0729dee
    {
        mantenerAgarrado=false;
        arco.SoltarCuerda();
    }
}

bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
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


    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.tag=="Cuerda"){
            arco = other.transform.parent.GetComponent<Arco>();
            tocandoCuarda=true;
            arco.TocarC();

        }

        
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Cuerda"&&!mantenerAgarrado)
            tocandoCuarda=false;
            arco.DejarDeTocarC();
    }
}
