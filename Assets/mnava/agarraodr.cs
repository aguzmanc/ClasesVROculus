using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarraodr : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

    [Range (0f,1f)]
    public float NivelAgarre;
    public arcoMN arcoGlo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       bool cambio=actualizarAgarre();
       if(estaAgarrando && arcoGlo!=null)
       {
           arcoGlo.agarrar(transform);
       }
       if(estaAgarrando==false && cambio && arcoGlo!=null){
            arcoGlo.soltar();
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
            cambio=false;
        }
        NivelAgarre=actual;
        return cambio;
    }
    void OnTriggerEnter(Collider other) {
       arcoMN arcoMano = other.GetComponent<arcoMN>();

        if(arcoMano!=null) {
            arcoGlo=arcoMano;
            arcoGlo.tocar();
        }
        
    }
     void OnTriggerExit(Collider otro) {
        arcoMN arcoMano = otro.GetComponent<arcoMN>();
        if(arcoMano!=null) {
            arcoGlo.dejarTocar();
            arcoGlo = null;
        }
     }
}
