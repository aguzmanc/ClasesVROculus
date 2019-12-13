using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorBallestaRoja : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

    public bool AGARREF;
    [Range (0f,1f)]
    public float NivelAgarre;
    public BallestaRoja ballestaRoja;

    public bool shootForzado,recargaForzada;
    void Update() {

        bool cambio = actualizarAgarre();

        if(estaAgarrando && ballestaRoja!=null)
        {
            ballestaRoja.agarrar(transform);
        }
        if(estaAgarrando==false && cambio && ballestaRoja!=null)
        {
                ballestaRoja.soltar();
        }

        //Disparo
        if(estaAgarrando && ballestaRoja != null &&( (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,OVRInput.Controller.RTouch))>0.3f ))
        {
            bool cargada=ballestaRoja.Cargada();
            if(cargada)
            {
                ballestaRoja.disparar();
            }
        }
    }

    bool actualizarAgarre()
    {
            bool cambio=false;
            float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
            if(NivelAgarre < limiteAgarre && actual >= limiteAgarre)
            {
                estaAgarrando=true;
                cambio=true;
            }
            if(NivelAgarre > LimiteSuelto && actual <= LimiteSuelto)
            {
                estaAgarrando=false;
                cambio=true;
            }
            NivelAgarre=actual;
            return cambio;
    }

    void OnTriggerEnter(Collider c) 
    {
        if(c.tag=="arma")
        {
            BallestaRoja ballestaTocada = c.GetComponent<BallestaRoja>();
            
            if(ballestaTocada!=null) {
                ballestaRoja=ballestaTocada;
                ballestaRoja.tocar();
            }
        }
    }

    void OnTriggerExit(Collider c) 
    {
         if(c.tag=="arma")
         {
            BallestaRoja ballestaTocada = c.GetComponent<BallestaRoja>();
            if(ballestaTocada!=null) {
                ballestaRoja.dejarTocar();
                ballestaRoja = null;
            }
        }
    }
}
