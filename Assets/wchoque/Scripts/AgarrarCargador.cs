using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCargador : MonoBehaviour
{
   
    public CargadorArma cargadorArma;
    // Start is called before the first frame update
        const float limite_Agarre=0.7f;
    const float limite_Soltar=0.3f;
    [Range(0,1)]
    public float agarre;
    bool cambio;
    public bool estaAgarrando;
    float actual;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cambio = UpdateNivelAgarre();
        cambio = true;
        if(estaAgarrando&& cargadorArma!=null && cambio){
            cargadorArma.Agarrar(transform);
        }
        if(!estaAgarrando&&cambio&&cargadorArma!=null){
            cargadorArma.soltar();
        }

 


    }
      bool UpdateNivelAgarre(){
        actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
        bool limiteTraspasado=false;
        if(agarre<limite_Agarre && actual>=limite_Agarre){
            estaAgarrando=true;
            limiteTraspasado =true;
        }
        if(agarre>limite_Soltar && actual<=limite_Soltar){
        estaAgarrando=false;
        limiteTraspasado =true;
        }
    agarre = actual;
    return limiteTraspasado;
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cargador"){
            CargadorArma cargaArma = other.GetComponent<CargadorArma>();
            if(cargaArma!=null){
                cargadorArma = cargaArma;
                cargadorArma.Tocar(); 
            }
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
         if(other.tag == "Cargador"){
            CargadorArma cargaArma = other.GetComponent<CargadorArma>();
            if(cargaArma!=null){
                cargadorArma = cargaArma;
                cargadorArma.DegarTocar();
                cargadorArma=null; 
            }
        }
    }

  
}
