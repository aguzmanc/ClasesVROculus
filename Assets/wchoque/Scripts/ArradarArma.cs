using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArradarArma : MonoBehaviour
{
    int cantidadMuniciones =10;
    public CuadroTiempo cuadroTiempo;
    public Arma armaMano;
    const float limite_Agarre=0.7f;
    const float limite_Soltar=0.3f;
    [Range(0,1)]
    public float agarre;
    bool cambio;
    public bool estaAgarrando;
    float actual;
    // Start is called before the first frame update
    void Start()
    {
        estaAgarrando =false;
        
    }

    // Update is called once per frame
    void Update()
    {   


        cambio = UpdateNivelAgarre();
        cambio = true;
        if(estaAgarrando&& armaMano!=null && cambio){
            armaMano.Agarrar(transform);
        }
        if(!estaAgarrando&& cambio && armaMano!=null){
            armaMano.soltar();
        }
        
         /*if(agarradorCuerdaBallesta!=null){
            //OVRInput.Button.PrimaryIndexTrigger
         // if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch) && agarradorCuerdaBallesta.prepararMunicion==true &&estaagarrando==true){
                if(Input.GetKeyDown(KeyCode.T) && agarradorCuerdaBallesta.prepararMunicion==true){
                agarradorCuerdaBallesta.lanzarFlecha();
            }
            //Index trigger para disparar
        }*/
    }
    bool UpdateNivelAgarre(){
        actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
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
    
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arma"){
            Arma armaV = other.GetComponent<Arma>();
            if(armaV!=null){
                armaMano = armaV;
                armaMano.Tocar(); 
            }
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
         if(other.tag == "Arma"){
            Arma armaV = other.GetComponent<Arma>();
            if(armaV!=null){
                armaMano = armaV;
                armaMano.DegarTocar();
                armaMano=null; 
            }
        }
    }
}
