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

    public Transform hand;
private void Update() {
    if(estaAgarrando&&tocandoCuarda)
    {
        mantenerAgarrado=true;
        hand.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionZ;
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
        tocandoCuarda=other.name=="Cuerda";
    }
    private void OnTriggerStay(Collider other) {
       // mantenerAgarrado=tocandoCuarda&&OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch)>LIMITE_AGARRE;
    }
    private void OnTriggerExit(Collider other) {
        if(other.name=="Cuerda"&&!mantenerAgarrado)
            tocandoCuarda=false;
    }
}
