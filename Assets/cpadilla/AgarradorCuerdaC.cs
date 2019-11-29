using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdaC : MonoBehaviour
{
    const float LIMITE_AGARRE=0.7F;
    const float LIMITE_SOLTAR = 0.3F;
      public bool estaAgarrando;

    [Range (0f,1f)]
    public float NivelAgarre;
    public CuerdaC cuerdaGlobal;
    public bool estatocada;
    public float distancia;
    public Transform origenCuerda;

     public bool agarreF;
     bool agarrada;
     public Transform flecha;
    // Start is called before the first frame update
    void Start()
    {
        estatocada=false;
        agarrada=false;
    }

    // Update is called once per frame
    
    void Update()
    {

        if(agarreF)
        {
            distancia=Vector3.Distance(transform.position,origenCuerda.transform.position);
            distancia=Mathf.Max(0f,distancia);
            distancia=Mathf.Min(1.6f,distancia);
            Debug.DrawLine(transform.position,origenCuerda.position,Color.green);
            if(distancia>0)
            {
               
                flecha feleCuer=flecha.GetComponent<flecha>(); 
                flecha.parent=cuerdaGlobal.transform;
                feleCuer.volverK();
                feleCuer.tp();
                feleCuer.darf(distancia);
                agarrada=true;
            }

        }
        else
        {
            distancia=0f;
            if(agarrada)
            {
                flecha feleCuer=flecha.GetComponent<flecha>(); 
                feleCuer.cambiarK();
            }
        }
        if(cuerdaGlobal!=null)
        {
            cuerdaGlobal.transform.localPosition=new Vector3(0,0,distancia*2);
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
        if(NivelAgarre<LIMITE_AGARRE && actual>=LIMITE_AGARRE)
        {
            estaAgarrando=true;
            cambio=true;
        }
        if(NivelAgarre>LIMITE_SOLTAR && actual<=LIMITE_SOLTAR)
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
            CuerdaC cuerdaTocada = other.GetComponent<CuerdaC>();
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
        CuerdaC cuerdaTocada = other.GetComponent<CuerdaC>();
        if(cuerdaTocada!=null) {
            cuerdaGlobal.dejarTocar();
            //cuerdaGlobal = null;
            estatocada=false;
             //origenCuerda=null;
        }
     }
     }
}
