using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarreBallestaIzquierda : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

  
    [Range (0f,1f)]
    public float NivelAgarre;
    public SoporteBallesta soporteBallesta;
  
public bool forzado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       bool cambio=actualizarAgarre();
   
       if(estaAgarrando && soporteBallesta!=null)
       {
           soporteBallesta.agarrar(transform);
       }
       if(estaAgarrando==false && cambio && soporteBallesta!=null){
            soporteBallesta.soltar();
        }

        if(estaAgarrando && soporteBallesta!=null)
        {
            soporteBallesta.rotar(transform);
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
     void OnTriggerEnter(Collider other) 
    {
      
       SoporteBallesta ballestaTocada = other.GetComponent<SoporteBallesta>();

        if(ballestaTocada!=null) {
            soporteBallesta=ballestaTocada;
            soporteBallesta.tocar();
      
        }
        
    }
    void OnTriggerExit(Collider otro) 
    {
        
        SoporteBallesta ballestaTocada = otro.GetComponent<SoporteBallesta>();
        if(ballestaTocada!=null) {
            soporteBallesta.dejarTocar();
            soporteBallesta = null;
        
        }
    }
    
}
