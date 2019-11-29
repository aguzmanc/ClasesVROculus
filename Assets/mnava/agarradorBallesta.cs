using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarradorBallesta : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

    public bool AGARREF;
    [Range (0f,1f)]
    public float NivelAgarre;
    public ballestaAgarrable ballestaglobal;

    public bool shootForzado,recargaForzada;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
       bool cambio=actualizarAgarre();
   
       if(estaAgarrando && ballestaglobal!=null)
       {
           ballestaglobal.agarrar(transform);
       }
       if(estaAgarrando==false && cambio && ballestaglobal!=null){
            ballestaglobal.soltar();
        }


        //recargar
        if(estaAgarrando && ballestaglobal!=null&& OVRInput.Get(OVRInput.Button.One))
        //if(AGARREF && ballestaglobal!=null&&recargaForzada)
        {
            bool cargada=ballestaglobal.Cargada();
            if(!cargada)
            {
                ballestaglobal.recargar();
                Debug.Log("Reload");
            }
        }
        //disprar
        if(estaAgarrando && ballestaglobal!=null&&( (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,OVRInput.Controller.RTouch))>0.3f ))
        //if(AGARREF && shootForzado && ballestaglobal!=null)
        {
            bool cargada=ballestaglobal.Cargada();
            if(cargada)
            {
                ballestaglobal.disparar();
                Debug.Log("BANG");
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
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="arma")
        {
       ballestaAgarrable ballestaTocada = other.GetComponent<ballestaAgarrable>();
        
        if(ballestaTocada!=null) {
            ballestaglobal=ballestaTocada;
            ballestaglobal.tocar();
        }
    }
        
    }
    void OnTriggerExit(Collider otro) 
    {
         if(otro.tag=="arma")
         {
        ballestaAgarrable ballestaTocada = otro.GetComponent<ballestaAgarrable>();
        if(ballestaTocada!=null) {
            ballestaglobal.dejarTocar();
            ballestaglobal = null;
        }
          }
    }
}
