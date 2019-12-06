using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador : MonoBehaviour
{
    bool toque2Manos;
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
     bool estaAgarrando;
     byte tipoArma;//0= nada, 1 una mano, 2 dos manos
    public bool AGARREF;
    [Range (0f,1f)]
    public float NivelAgarre;
     ArmaUnaMano arma;
     ArmaDosManos armaDos;



    void Start()
    {
        tipoArma=0;
        toque2Manos=false;
    }

   
    void Update()
    {

       bool cambio=actualizarAgarre();


       //estaAgarrando=AGARREF;//agarre forzado 

       if(tipoArma==1)
       {
            if(estaAgarrando && arma!=null)
            {
                arma.agarrar(transform);
            }
            if(estaAgarrando==false && cambio && arma!=null)
            {
                arma.soltar();
                tipoArma=0;
            }
       }
       else if(tipoArma==2)
       {
            if(estaAgarrando && armaDos!=null)
            {
                armaDos.agarrarBase();
                if(armaDos.dosmanos())
                {
                    armaDos.AgarrarFull(transform);
                }
            }
            if(estaAgarrando==false && cambio && armaDos!=null)
            {
                arma.soltar();
                tipoArma=0;
            }
       }
       if(toque2Manos)
       {
           if(estaAgarrando && armaDos!=null)
           {
               armaDos.agarrarAp();
           }
       }
    }
    bool actualizarAgarre()
    {
        bool cambio=false;
        float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
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
        Debug.Log(other.name);
        if(other.tag=="Arma1")
        {
            ArmaUnaMano armaTocada = other.GetComponent<ArmaUnaMano>();
            if(armaTocada!=null) 
            {
                arma=armaTocada;
                arma.tocar();
                tipoArma=1;
            }
        }
        else if(other.tag=="Arma2")
        {
            ArmaDosManos armaTocada = other.GetComponent<ArmaDosManos>();
            if(armaTocada!=null) 
            {
                armaDos=armaTocada;
                armaDos.tocar();
                tipoArma=2;
            }
        }
         if(other.tag=="Apoyo")
        {
            Debug.Log("app");
            ArmaDosManos armaTocada = other.GetComponentInParent<ArmaDosManos>();
            if(armaTocada!=null) 
            {
                armaDos=armaTocada;
                armaDos.tocarAp();
                toque2Manos=true;
               
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
                tipoArma=0;
            }
        }
        else if(other.tag=="Arma2")
        {
            ArmaDosManos armaTocada = other.GetComponent<ArmaDosManos>();
            if(armaTocada!=null)
            {
                armaDos.dejarTocar();
                armaDos = null;
                tipoArma=0;
            }
        }
        else if(other.tag=="Apoyo")
        {
            ArmaDosManos armaTocada = other.GetComponentInParent<ArmaDosManos>();
            if(armaTocada!=null)
            {
                armaDos.dejarTocarAp();
                toque2Manos=false;
            }
        }
     }
}
