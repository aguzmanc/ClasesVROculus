using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarBallestaIP : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool isTaken;

    public BallestaIP ballesta;

    public bool agarrar=false;
    
    public bool sePuedeDisparar=false;
    
    public GameObject prefabFlecha;
    public GameObject flecha;
    
    void Start()
    {   
        isTaken = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        bool cambio = UpdateNivelAgarre();
        
        if(isTaken && ballesta != null && cambio) {
            if (ballesta!=null)
            {
                sePuedeDisparar=true;
                ballesta.Agarrar(transform);
                
            }
            
        }

        if(isTaken==false && cambio && ballesta!=null){
            if (ballesta!=null)
            {
                sePuedeDisparar=false;
                ballesta.Soltar();
            }
            
        }

        bool disparo = UpdateTrigger();
        if (isTaken && ballesta != null && disparo)
        {
            if (ballesta!=null)
            {
                if (sePuedeDisparar && disparo)
                {
                    sePuedeDisparar=false;

                    flecha=Instantiate(prefabFlecha,transform.position,transform.rotation);
                    flecha.transform.forward=-transform.forward;
                    // FlechaIP miFlecha=flecha.GetComponent<FlechaIP>();
                    // miFlecha.Disparar(10f);
                }
                
            }
        }
    }

    bool UpdateTrigger(){
        float val =OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,OVRInput.Controller.LTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && val >= LIMITE_AGARRE){
            isTaken = true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && val <= LIMITE_SOLTAR){
            isTaken = false;
            limiteTraspasado = true;
        }

        agarre = val;

        return limiteTraspasado;
    }
    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            isTaken = true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            isTaken = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }

    void OnTriggerEnter(Collider otro) {
        BallestaIP ballestaA = otro.GetComponent<BallestaIP>();

        if(ballestaA!=null) {
            ballesta = ballestaA;
            ballesta.Tocar();
        }
    }


    void OnTriggerExit(Collider otro) {
        BallestaIP ballestaA = otro.GetComponent<BallestaIP>();
        if(ballestaA!=null) {
            ballesta.DejarDeTocar();
            ballesta = null;
        }
    }
}
