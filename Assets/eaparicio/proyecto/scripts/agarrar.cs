using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    public float LIMITE_AGARRE=0.7F;
    public float LIMITE_SOLTAR=0.3F;
    public bool estaAgarrado;

    public bate bate;


     [Range(0f, 1f)]
    public float agarre;
     [Range(0f, 1f)]
    public float actu;


    public bool cambio;
    public bool tocado;

    void Start()
    {
        tocado=false;
        estaAgarrado=false;
    }

    void Update()
    {
        cambio = UpdateAgarre();
        if( bate!=null && cambio)
        {
            if (estaAgarrado)
            {
                if (tocado)
                {
                    bate.Agarrar(transform);
                }
            }
            if(!estaAgarrado){
                bate.Soltar();
            }
        }
       
    }
    bool limitePasado;
    public float actual;
    bool UpdateAgarre(){

        //PRUEBAS PC
        actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        limitePasado=false;
        if (agarre<LIMITE_AGARRE && actu>=LIMITE_AGARRE)
        {
            estaAgarrado=true;
            limitePasado=true;
        }
        if (agarre>LIMITE_SOLTAR && actu <=LIMITE_SOLTAR)
        {
            estaAgarrado=false;
            limitePasado=true;
        }
        agarre=actu;
        // if (agarre<LIMITE_AGARRE && actual>=LIMITE_AGARRE)
        // {
        //     estaAgarrado=true;
        //     limitePasado=true;
        // }
        // if (agarre>LIMITE_SOLTAR && actual <=LIMITE_SOLTAR)
        // {
        //     estaAgarrado=false;
        //     limitePasado=true;
        // }
        // agarre=actual;
        return limitePasado;



        //PRUEBAS VR
        // float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        // bool limitePasado=false;
        // if (agarre<LIMITE_AGARRE && actual>=LIMITE_AGARRE)
        // {
        //     estaAgarrado=true;
        //     limitePasado=true;
        // }
        // if (agarre>LIMITE_SOLTAR && actual <=LIMITE_SOLTAR)
        // {
        //     estaAgarrado=false;
        //     limitePasado=true;
        // }
        // agarre=actual;
        // return limitePasado;
    }

    IEnumerator MovimientoBrusco()
    {   
        Vector3 origen;
        Vector3 mg;
        while(true){
            if (bate!=null)
            {
                
                origen = transform.position;
                yield return new WaitForSeconds(1f);
                mg = transform.position-origen;
                Debug.Log(mg);
                // if (mg.magnitude>0.1f)
                // {
                    
                // }
            }
        }

    }

    void OnTriggerEnter(Collider otro) {
        Debug.Log(otro.name);
        tocado=true;
        if (otro.name=="agarre")
        {
            bate b = otro.GetComponent<bate>();
            if (b!=null)
            {
                StartCoroutine(MovimientoBrusco());
                bate = b;
                b.Tocar();
            }
        }
    }
    

    void OnTriggerExit(Collider otro)
    {
        tocado=false;
        Debug.Log(otro.name);
         if (otro.name=="agarre")
        {
            bate b = otro.GetComponent<bate>();
            if (b!=null)
            {
                StopAllCoroutines();
                bate = b;
                b.DejarTocar();
            }
        }
    }
}
