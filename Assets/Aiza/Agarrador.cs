using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador : MonoBehaviour
{
    const float LIMITE_AGARRE=0.7F;
    const float LIMITE_SOLTAR = 0.3F;

    [Range(0f,1f)]
    public float agarre;

    public bool estaAgarrando;
    public Taco taco;
    // Start is called before the first frame update
    void Start()
    {
        estaAgarrando=false;
    }

    // Update is called once per frame
    void Update()
    {
        
        bool cambio = UpdateNivelAgarre();

        if (estaAgarrando && taco !=null && cambio)
        {
            taco.Agarrar(transform);
        }
        if (estaAgarrando == false && cambio && taco !=null)
        {
            taco.Soltar();
        }

        //mi debug
        /*

        if (estaAgarrando && taco !=null )
        {
            taco.Agarrar(transform);
        }

        if (estaAgarrando == false  && taco !=null)
        {
            taco.Soltar();
        }*/
    }


    bool UpdateNivelAgarre()
    {
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
        bool limiteTraspado = false;
        if (agarre < LIMITE_AGARRE && actual >= LIMITE_AGARRE)
        {
            estaAgarrando=true;
            limiteTraspado=true;
        }
        if (agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
        {
            estaAgarrando=false;
            limiteTraspado=true;
        }
        agarre = actual;
        return limiteTraspado;
    }

    private void OnTriggerEnter(Collider other) {
        Taco tacoAgarrado =  other.GetComponentInParent<Taco>();
        if (tacoAgarrado!=null)
        {
            taco = tacoAgarrado;
            taco.Tocar();
        }
    }

    private void OnTriggerExit(Collider other) {
        Taco tacoAgarrado =  other.GetComponentInParent<Taco>();
        if (tacoAgarrado!=null)
        {
            taco.DejarDeTocar();
            taco = null;
        }
    }
}
