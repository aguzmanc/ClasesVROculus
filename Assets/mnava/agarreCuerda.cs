using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarreCuerda : MonoBehaviour
{
    const float limiteAgarre = 0.7f;
    const float LimiteSuelto = 0.3f;
    public bool estaAgarrando;

    [Range (0f,1f)]
    public float NivelAgarre;
    public cuerdaFisica cuerdaGlobal;
    public bool estatocada;
    public float distancia;
    public Transform origenCuerda;
     bool flechaC;
     public Transform flecha;
    // Start is called before the first frame update
    void Start()
    {
        estatocada=false;
        flechaC=false;
    }

    // Update is called once per frame
    
    void Update()
    {

        if(estaAgarrando&&origenCuerda!=null)
        {
            distancia=Vector3.Distance(transform.position,origenCuerda.transform.position);
            distancia=Mathf.Max(0f,distancia);
            distancia=Mathf.Min(1.6f,distancia);
            Debug.DrawLine(transform.position,origenCuerda.position,Color.green);
            if(distancia>0)
            {
                flechaC=true;
                fidicasFlecha feleCuer=flecha.GetComponent<fidicasFlecha>(); 
                feleCuer.volverK();
                feleCuer.tp();
            }

        }
        else
        {
            distancia=0f;
             flechaC=false;
             fidicasFlecha feleCuer=flecha.GetComponent<fidicasFlecha>(); 
             feleCuer.cambiarK();
        }
        if(cuerdaGlobal!=null)
        {
            cuerdaGlobal.transform.localPosition=new Vector3(0,0,distancia*2);
        }

        if(flechaC)
        {
            flecha.parent=cuerdaGlobal.transform;
        }




        
       bool cambio=actualizarAgarre();
        if(estaAgarrando && cambio) {
            if(cuerdaGlobal != null)
                cuerdaGlobal.agarrar();   
        }

        if(estaAgarrando==false && cuerdaGlobal!=null){
            if(cuerdaGlobal!=null)
                cuerdaGlobal.soltar();
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
        if(other.tag=="CuerdaPoint")
        {
            cuerdaFisica cuerdaTocada = other.GetComponent<cuerdaFisica>();
            if(cuerdaTocada!=null) {
                cuerdaGlobal=cuerdaTocada;
                cuerdaGlobal.tocar();
                estatocada=true;
                origenCuerda=cuerdaGlobal.transform.parent;
            }
        }
       
        
    }
     void OnTriggerExit(Collider other) {
         if(other.tag=="CuerdaPoint")
        {
        cuerdaFisica cuerdaTocada = other.GetComponent<cuerdaFisica>();
        if(cuerdaTocada!=null) {
            cuerdaGlobal.dejarTocar();
            cuerdaGlobal = null;
            estatocada=false;
            origenCuerda=null;
        }
     }
     }
}
