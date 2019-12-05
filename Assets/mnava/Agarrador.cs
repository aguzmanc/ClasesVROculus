using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

    public bool AGARREF;
    [Range (0f,1f)]
    public float NivelAgarre;
    public ArmaUnaMano arma;



    void Start()
    {
        
    }

   
    void Update()
    {

       bool cambio=actualizarAgarre();


       estaAgarrando=AGARREF;//agarre forzado 
       if(estaAgarrando && arma!=null)
       {
           arma.agarrar(transform);
       }
       if(estaAgarrando==false && cambio && arma!=null){
            arma.soltar();
        }
    }
    bool actualizarAgarre()
    {
        bool cambio=false;
        float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
        if(NivelAgarre<limiteAgarre && actual>=limiteAgarre)
        {
            estaAgarrando=true;
            cambio=true;
        }
        if(NivelAgarre>LimiteSuelto && actual<=LimiteSuelto)
        {
            estaAgarrando=false;
            cambio=true;
        }
        NivelAgarre=actual;
        return cambio;
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag=="Arma1")
        {
            ArmaUnaMano armaTocada = other.GetComponent<ArmaUnaMano>();
            if(armaTocada!=null) 
            {
                arma=armaTocada;
                arma.tocar();
            }
        }
        
    }
     void OnTriggerExit(Collider other) {
        if(other.tag=="Arma1")
        {
            ArmaUnaMano armaTocada = other.GetComponent<ArmaUnaMano>();
            if(armaTocada!=null)
            {
                arma.dejarTocar();
                arma = null;
            }
        }
     }
}
