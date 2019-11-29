using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarCuerdaEA : MonoBehaviour
{
    public float LIMITE_AGARRE=0.7F;
    public float LIMITE_SOLTAR=0.3F; 

    public bool limiteBallesta;
    public bool gatilloBallesta;
    public bool culataAgarrada;
    public bool culataDisparo;


    [Range(0f, 1f)]
    public float agarreCuerda;
    public bool estaAgarrado;

    public float distancia;
    public bool tocando;
    public Transform pivotCuerda;
    
    cuerdaEA cuerdaEA;
    culataBallesta culataBallesta;

    public GameObject ballesta;
    public Transform izquierda;
    public Transform derecha;


    [Range(0f, 1f)]
    public float actu;
    void Start()
    {
        tocando = false;
        estaAgarrado = false;
        limiteBallesta=false;
        gatilloBallesta=false;
        culataAgarrada=false;
        culataDisparo=false;
    }

    bool cambio;
    Vector3 direccionManos;
    void Update()
    {
        // direccionManos = izquierda.transform.position-derecha.transform.position;
        // ballesta.transform.rotation = Quaternion.Slerp(ballesta.transform.rotation, Quaternion.LookRotation(direccionManos), 0.1f);


        if (!limiteBallesta)
        {
            if(estaAgarrado) {
            
            distancia = Vector3.Distance(transform.position, pivotCuerda.position);
            distancia = Mathf.Max(0f, distancia);
            distancia = Mathf.Min(0.5f, distancia);

        } else
            distancia = 0;
        }
        else
            distancia=0.5f;
        

        if(cuerdaEA!=null)
            cuerdaEA.transform.parent.localPosition = new Vector3(0,0,distancia);


        



        cambio = UpdateAgarre();
        
        if (limiteBallesta)
        {
            if(estaAgarrado && cambio) {
                if(culataBallesta != null)
                {
                    culataBallesta.Agarrar();   
                    culataAgarrada=true;
                }
            }
            if(estaAgarrado==false && culataBallesta!=null){
                if (tocando)
                {
                    culataBallesta.Soltar();
                }
                else
                {
                    culataBallesta.DejarTocar();
                }
            }
            //if (culataDisparo || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RTouch))
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Debug.Log("Disparo");
                //DISPARAR FLECHA
                Transform flecha = culataBallesta.transform.parent.FindChild("cuerda").GetChild(0);
                flecha.GetComponent<disparoFlecha>().Disparar(distancia);
                flecha.parent=null;
                limiteBallesta=false;
                estaAgarrado=false;
                cuerdaEA=null; 
            }
            if (culataAgarrada)
            {
                direccionManos = izquierda.transform.position-derecha.transform.position;
                ballesta.transform.rotation = Quaternion.Slerp(ballesta.transform.rotation, Quaternion.LookRotation(direccionManos), 0.1f);
            }
        }
        else
        {
            if(estaAgarrado && cambio) {
                if(cuerdaEA != null)
                    cuerdaEA.Agarrar();   
            }

            if(estaAgarrado==false && cuerdaEA!=null){
                if(!tocando)
                {
                    cuerdaEA.DejarTocar();
                    if(!gatilloBallesta){
                        if (distancia>0.1f)
                        {
                            cuerdaEA.transform.parent.GetComponentInParent<disparoFlecha>().Disparar(distancia);   
                            cuerdaEA.transform.parent.parent=null;  
                            cuerdaEA=null;                  
                        }
                    }
                }

            }
        }

        

        
    }

    bool UpdateAgarre(){


        //PRUEBAS PC
        // bool limiteTraspasado = false;

        // if(agarreCuerda < LIMITE_AGARRE  && actu >= LIMITE_AGARRE && tocando){
        //     estaAgarrado = true;
        //     limiteTraspasado = true;
        // }

        // if(agarreCuerda > LIMITE_SOLTAR && actu <= LIMITE_SOLTAR){
        //     estaAgarrado = false;
        //     limiteTraspasado = true;
        // }

        // agarreCuerda = actu;

        // return limiteTraspasado;

        //PRUEBAS VR
       float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool limiteTraspasado = false;

        if(agarreCuerda < LIMITE_AGARRE  && actual >= LIMITE_AGARRE && tocando){
            estaAgarrado = true;
            limiteTraspasado = true;
        }

        if(agarreCuerda > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            estaAgarrado = false;
            limiteTraspasado = true;
        }

        agarreCuerda = actual;

        return limiteTraspasado;

    }

    

     private void OnTriggerEnter(Collider otro) {
        
        if(otro.tag == "cuerda"){
            if(!estaAgarrado){
                cuerdaEA = otro.GetComponent<cuerdaEA>();
                cuerdaEA.Tocar();
                tocando = true;
                pivotCuerda = cuerdaEA.transform.parent.parent;
            }
        }
        if (otro.name=="culata")
        {
            if(!estaAgarrado){
                culataBallesta = otro.GetComponent<culataBallesta>();
                culataBallesta.Tocar();
                tocando = true;
            }
        }
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.tag=="cuerda")
        {
            cuerdaEA = otro.GetComponent<cuerdaEA>();
            if(!estaAgarrado){
                cuerdaEA.DejarTocar();
            }
            tocando = false;

            
        }
    }

    public void LimiteBallestaPasado(){
        if (estaAgarrado)
        {
            limiteBallesta=true;
            gatilloBallesta=true;
            cuerdaEA.Ballesta();
        }

    }
}
