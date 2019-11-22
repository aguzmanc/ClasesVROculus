using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarradora : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f,1f)]
    public float agarre;
    public ArcoA arco;


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

      if(estaAgarrando && arco!=null && cambio)
      {
            arco.Agarrar(transform);
      }
      if(estaAgarrando==false && cambio && arco!=null)
      {
        arco.Soltar();
      }
    }

   bool UpdateNivelAgarre()
    {
        bool limiteTraspasado=false;
  float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
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
            Debug.Log(actual);
        return limiteTraspasado;
        
    }

    private void OnTriggerEnter(Collider other) {
       ArcoA arcoAgarrado = other.GetComponent<ArcoA>();
       if(arcoAgarrado!=null)
       {
           arco=arcoAgarrado;
           arco.Tocar();
       }
        Debug.Log(other.name);
    }


     private void OnTriggerExit(Collider other) {
         ArcoA arcoAgarrado = other.GetComponent<ArcoA>();
         if(arcoAgarrado!=null)
       {
           
           arco.DejarDeTocar();
           arco =null;
       }
    }
}
