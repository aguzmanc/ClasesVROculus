using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarCuerdaEA : MonoBehaviour
{
    public float LIMITE_AGARRE=0.7F;
    public float LIMITE_SOLTAR=0.3F;    

    [Range(0f, 1f)]
    public float agarreCuerda;
    public bool estaAgarrado;

    public float distancia;
    public bool tocando;
    public Transform pivotCuerda;
    cuerdaEA cuerdaEA;


    [Range(0f, 1f)]
    public float actu;
    void Start()
    {
        tocando = false;
        estaAgarrado = false;
    }

    bool cambio;
    void Update()
    {
        
        if(estaAgarrado) {
            
            distancia = Vector3.Distance(transform.position, pivotCuerda.position);
            distancia = Mathf.Max(0f, distancia);
            distancia = Mathf.Min(0.5f, distancia);
            Debug.DrawLine(transform.position, pivotCuerda.position, Color.green);

        } else
            distancia = 0;

        if(cuerdaEA!=null)
            cuerdaEA.transform.parent.localPosition = new Vector3(0,0,distancia);


        



        cambio = UpdateAgarre();
        
        if(estaAgarrado && cambio) {
            if(cuerdaEA != null)
                cuerdaEA.Agarrar();   
        }

        if(estaAgarrado==false && cuerdaEA!=null){
            if(cuerdaEA!=null){
                if(tocando)
                    cuerdaEA.Soltar();
                else
                {
                    if (cuerdaEA!=null)
                    {
                        cuerdaEA.DejarTocar();
                        if (distancia>0.1f)
                        {
                            cuerdaEA.transform.parent.GetComponentInParent<disparoFlecha>().Disparar(distancia);   
                            cuerdaEA.transform.parent.parent=null;                    
                        }
                    }
                }

            }
        }

        
    }

    bool UpdateAgarre(){


        bool limiteTraspasado = false;

        if(agarreCuerda < LIMITE_AGARRE  && actu >= LIMITE_AGARRE && tocando){
            estaAgarrado = true;
            limiteTraspasado = true;
        }

        if(agarreCuerda > LIMITE_SOLTAR && actu <= LIMITE_SOLTAR){
            estaAgarrado = false;
            limiteTraspasado = true;
        }

        agarreCuerda = actu;

        return limiteTraspasado;


    //    float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
    //     bool limiteTraspasado = false;

    //     if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE && tocando){
    //         estaAgarrando = true;
    //         limiteTraspasado = true;
    //     }

    //     if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
    //         estaAgarrando = false;
    //         limiteTraspasado = true;
    //     }

    //     agarre = actual;

    //     return limiteTraspasado;

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
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.tag=="cuerda")
        {
            cuerdaEA = otro.GetComponent<cuerdaEA>();
            Debug.Log(estaAgarrado);
            if(!estaAgarrado){
                cuerdaEA.DejarTocar();
            }
            tocando = false;

            
        }
    }
}
