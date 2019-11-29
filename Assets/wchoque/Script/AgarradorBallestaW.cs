using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorBallestaW : MonoBehaviour
{
         //Ballesta 
      public BallestaW ballesta;
          //Configuraciones
    const float limite_agarre =0.7f;
    const float limite_soltar =0.3f;
  
    [Range(0,1)]
    public float agarre ;
    bool cambio;
    public bool estaagarrando;
    float actual;
    public bool agarradoIzquierda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           cambio= UpdateNivelAgarre();
     // cambio=true;
        if(estaagarrando && ballesta!=null && cambio){
              agarradoIzquierda =true;
            ballesta.Agarrar(transform);
          
        }
        if(!estaagarrando && cambio && ballesta!=null){
              agarradoIzquierda=false;
            ballesta.Soltar();
          
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
        if(other.tag == "Ballesta"){
            BallestaW balle = other.GetComponent<BallestaW>();
            ballesta = balle;
            ballesta.Tocar();
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
          if(other.tag == "Ballesta"){
            BallestaW balle = other.GetComponent<BallestaW>();
              if(balle!=null){
             ballesta.DejarTocar();
            // ballesta=null;
         }
            
        }
    }
}
