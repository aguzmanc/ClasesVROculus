using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorC : MonoBehaviour
{
    public ArcoC arco;

 
      //Configuraciones
    const float limite_agarre =0.7f;
    const float limite_soltar =0.3f;
  
    [Range(0,1)]
    public float agarre ;
    bool cambio;
    public bool estaagarrando;
    float actual;
    // Start is called before the first frame update
    void Start()
    {
        estaagarrando = false;
    }

    // Update is called once per frame
    void Update()
    {
     
       cambio= UpdateNivelAgarre();
      cambio=true;
        if(estaagarrando && arco!=null && cambio){
            arco.Agarrar(transform);
        }
        if(!estaagarrando && cambio && arco!=null){
            arco.Soltar();
            //Quaternion
        }
        
    }
    bool UpdateNivelAgarre(){
   actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
    bool limiteTraspasado=false;
        if(agarre<limite_agarre  && actual >=limite_agarre){
            estaagarrando =true;
            limiteTraspasado=true;
        }
        if(agarre>limite_soltar  && actual <=limite_soltar){
            estaagarrando =false;
            limiteTraspasado=true;
        }
        agarre=actual;
        return limiteTraspasado;
    }
     private void OnTriggerEnter(Collider other) {
         if(other.tag == "Arcos"){
            ArcoC arcoagarrado =other.GetComponent<ArcoC>();
            Debug.Log(arcoagarrado);
                if(arcoagarrado!=null){
             arco = arcoagarrado;
             arco.Tocar();
            }
         }
   
       
         Debug.Log(other.name);
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
         ArcoC arcoagarrado =other.GetComponent<ArcoC>();

         if(arcoagarrado!=null){
             arco.DejarTocar();
             arco=null;
         }
         Debug.Log(other.name);
    }
}
