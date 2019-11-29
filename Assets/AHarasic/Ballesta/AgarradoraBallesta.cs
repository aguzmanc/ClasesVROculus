using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradoraBallesta : MonoBehaviour
{

    
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;
    
    [Range(0f,1f)]
    public float agarre;

    public BallestaA ballesta;

    public bool estaAgarrando;

    // Start is called before the first frame update
    void Start()
    {
          estaAgarrando=false;
    }

    // Update is called once per frame
    void Update()
    {
        bool cambio = UpdateNivelAgarre();

      if(estaAgarrando && ballesta!=null && cambio)
      {
            ballesta.Agarrar(transform);
      }
      if(estaAgarrando==false && cambio &&ballesta!=null)
      {
        ballesta.Soltar();
      }
    }

 bool UpdateNivelAgarre()
    {
        bool limiteTraspasado=false;
        float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
        //float actual=0.8f;
    if( agarre<LIMITE_AGARRE && actual>=LIMITE_AGARRE)
    {
            estaAgarrando=true;
            limiteTraspasado=true;
    }
            if(agarre>LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
            {
                estaAgarrando=false;
                limiteTraspasado=true;
                
            }
            agarre=actual;
            //Debug.Log(actual);
        return limiteTraspasado;
        
    }



 private void OnTriggerEnter(Collider other) {
       BallestaA ballestaAgarrado = other.GetComponent<BallestaA>();
       if(ballestaAgarrado!=null)
       {
           ballesta=ballestaAgarrado;
           ballesta.Tocar();
       }
       // Debug.Log(other.name);
    }


     private void OnTriggerExit(Collider other) {
           BallestaA ballestaAgarrado = other.GetComponent<BallestaA>();
         if(ballestaAgarrado!=null)
       {
           
           ballesta.DejarDeTocar();
           ballesta =null;
       }
    }








}
