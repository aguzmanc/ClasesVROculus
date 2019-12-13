using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{

    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool grabActivado;

    public Rifle rifle;
    public bool armaAgarrada=false;
    float oldIndexValue=0f;
    float actualIndexValue=0f;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool cambio=UpdateNivelAgarre();
        if(grabActivado && rifle != null && cambio) {
            rifle.Agarrar(transform);
            armaAgarrada=true;
        }

        if(grabActivado==false && cambio && rifle!=null){
            rifle.Soltar();
            armaAgarrada=false;
        }

        if (armaAgarrada) {
            Rifle gunScript = rifle.GetComponent<Rifle>();

        oldIndexValue=actualIndexValue;
        actualIndexValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger,OVRInput.Controller.RTouch);
        if (actualIndexValue > 0.9f && oldIndexValue < 0.9f)
            gunScript.Disparar();
        }
    }


    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.RTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            grabActivado=true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            grabActivado=false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }

    void OnTriggerEnter(Collider otro) {
        Rifle rifleAgarrado = otro.GetComponent<Rifle>();
        if(rifleAgarrado!=null) {
            rifle = rifleAgarrado;
            rifle.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        Rifle rifleAgarrado = otro.GetComponent<Rifle>();
        if(rifleAgarrado!=null) {
            rifle = null;
            rifle.DejarDeTocar();
        }
    }
}

