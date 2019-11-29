using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorC : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

    public bool AGARREF;
    [Range (0f,1f)]
    public float NivelAgarre;
    public ArcoC arcoGlobal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       


        //estaAgarrando=true;
       bool cambio=actualizarAgarre();
       //bool cambio=false;
       if(AGARREF && arcoGlobal!=null)
       {
           arcoGlobal.agarrar(transform);
       }
       if(estaAgarrando==false && cambio && arcoGlobal!=null){
            arcoGlobal.soltar();
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
       ArcoC arcoMano = other.GetComponent<ArcoC>();

        if(arcoMano!=null) {
            arcoGlobal=arcoMano;
            arcoGlobal.tocar();
        }
        
    }
     void OnTriggerExit(Collider otro) {
        ArcoC arcoMano = otro.GetComponent<ArcoC>();
        if(arcoMano!=null) {
            arcoGlobal.dejarTocar();
            arcoGlobal = null;
        }
     }
    
}
