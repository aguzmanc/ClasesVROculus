using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCulataBallesta : MonoBehaviour
{
    
            const float limite_agarre =0.7f;
    const float limite_soltar =0.3f;

    AgarradorCuerdaBallesta agarradorCuerdaBallesta;
    // Start is called before the first frame update
    [Range(0,1)]
       public float agarre ;
    bool cambio;
    public bool estaagarrando;
    float actual;
    public float distancia;
     public float distanciaValor;
    public bool tocado;
    CulataBallesta culataBallesta;

    public bool agarradoDerecha;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agarradorCuerdaBallesta!=null){
            //OVRInput.Button.PrimaryIndexTrigger
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch) && agarradorCuerdaBallesta.prepararMunicion==true &&estaagarrando==true){
               //  if(Input.GetKeyDown(KeyCode.T) && agarradorCuerdaBallesta.prepararMunicion==true){
                agarradorCuerdaBallesta.lanzarFlecha();
            }
            //Index trigger para disparar
        }
         cambio= UpdateNivelAgarreDerecha();
      //cambio=true;
            if(estaagarrando  && cambio){
            if(culataBallesta!=null){
              agarradoDerecha = true;
            culataBallesta.Agarrar();
          }
        }
        if(!estaagarrando && cambio ){
            if(culataBallesta!=null){
             agarradoDerecha = false;
             culataBallesta.Soltar();
           }
        }
    }
         bool UpdateNivelAgarreDerecha(){
   actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
    bool limiteTraspasado=false;
        if(agarre<limite_agarre  && actual >=limite_agarre && tocado== true){
            estaagarrando =true;
            limiteTraspasado=true;
        }
        if(agarre>limite_soltar  && actual <=limite_soltar ){
            estaagarrando =false;
            limiteTraspasado=true;
        }
        agarre=actual;
        return limiteTraspasado;
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.name =="AgarreDisparo"){
            Debug.Log("entro al arco de la culata");
            culataBallesta = other.transform.GetComponent<CulataBallesta>();
            agarradorCuerdaBallesta = transform.GetComponent<AgarradorCuerdaBallesta>();
            culataBallesta.Tocar();
            tocado=true;
        }        
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
         if(other.name =="AgarreDisparo"){
            Debug.Log("entro al arco de la culata");
            culataBallesta = other.transform.GetComponent<CulataBallesta>();
            //agarradorCuerdaBallesta = transform.GetComponent<AgarradorCuerdaBallesta>();
            culataBallesta.DejarTocar();
            tocado=false;
            culataBallesta = null;
        }   
    }
}
