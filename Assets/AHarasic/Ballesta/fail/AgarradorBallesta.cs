using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorBallestaW : MonoBehaviour
{
         //Ballesta 
      public Ballesta ballesta;
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
        
    }

    // Update is called once per frame
    void Update()
    {
           cambio= UpdateNivelAgarre();
      //cambio=true;
        if(estaagarrando && ballesta!=null && cambio){
            ballesta.Agarrar(transform);
        }
        if(!estaagarrando && cambio && ballesta!=null){
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
            Ballesta balle = other.GetComponent<Ballesta>();
            ballesta = balle;
            ballesta.Tocar();
        }
    }
   
    void OnTriggerExit(Collider other)
    {
          if(other.tag == "Ballesta"){
            Ballesta balle = other.GetComponent<Ballesta>();
              if(balle!=null){
             ballesta.DejarTocar();
             ballesta=null;
         }
            
        }
    }
}
