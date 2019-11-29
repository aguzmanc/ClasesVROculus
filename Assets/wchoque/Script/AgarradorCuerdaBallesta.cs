using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdaBallesta : MonoBehaviour
{
     Rigidbody flecha;
       Transform pivotCuerda;
            const float limite_agarre =0.7f;
    const float limite_soltar =0.3f;
    CuerdaBallestaW cuerdaBallesta;
    
    [Range(0,1)]
       public float agarre ;
    bool cambio;
    public bool estaagarrando;
    float actual;
    public float distancia;
     public float distanciaValor;
    public bool tocado;
    public bool prepararMunicion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(estaagarrando){
            distancia = Vector3.Distance(transform.position,pivotCuerda.position);
            distancia = Mathf.Max(0f,distancia);
            distancia  = Mathf.Min(0.3f,distancia);
            Debug.DrawLine(transform.position,pivotCuerda.position,Color.green);
            Debug.Log(distancia + "distancia1");
            distanciaValor = distancia;
        }
        else {
            if(distancia<0.15f){
                distancia = 0;
                prepararMunicion = false;
            }

            //distancia =distancia;
          //  prepararMunicion = true;
        }
        if(cuerdaBallesta!=null){
            cuerdaBallesta.transform.localPosition =new Vector3(0,0,distancia);
            
           if(distancia>0.15f && flecha==null){
               flecha = cuerdaBallesta.proyectil();
               prepararMunicion = true;
            }
            if(distancia>0.15f && flecha!=null){
                prepararMunicion = true;
            }
        }


         cambio= UpdateNivelAgarreDerecha();
    //  cambio=true;
            if(estaagarrando  && cambio){
            if(cuerdaBallesta!=null)
            cuerdaBallesta.Agarrar();
        }
        if(!estaagarrando && cambio ){
            if(cuerdaBallesta!=null)
            cuerdaBallesta.Soltar();
           /* if(flecha !=null){
                flecha.transform.parent.transform.parent = null;
                flecha.isKinematic = false;
                flecha.AddForce(transform.parent.transform.forward * distanciaValor * 1000, ForceMode.Force);
                flecha =null;
                
            }*/
            
        }
    }
     bool UpdateNivelAgarreDerecha(){
   actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
    bool limiteTraspasado=false;
        if(agarre<limite_agarre  && actual >=limite_agarre){
            estaagarrando =true;
            limiteTraspasado=true;
        }
        if(agarre>limite_soltar  && actual <=limite_soltar){
            estaagarrando =false;
            limiteTraspasado=true;
        }
        agarre=actual;
        return limiteTraspasado;
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CuerdaBallesta"){
            Debug.Log("Tocar Cuerda");
            cuerdaBallesta =  other.transform.GetComponent<CuerdaBallestaW>();

            cuerdaBallesta.Tocar();
            tocado=true;
            pivotCuerda = cuerdaBallesta.transform.parent;
           /*  Cuerda cuerda =other.GetComponent<Cuerda>();
            cuerda.Tocar();*/
        }
    }
    private void OnTriggerExit(Collider other) {
         if(other.tag=="CuerdaBallesta"){
             Debug.Log("Dejar de Tocar Cuerda");
            cuerdaBallesta =  other.transform.GetComponent<CuerdaBallestaW>();
            cuerdaBallesta.DejarTocar();
           // cuerda=null;
           tocado=false;
           /* Cuerda cuerda =other.GetComponent<Cuerda>();
            cuerda.DejarTocar();*/
        }
    }
    public void lanzarFlecha(){
        if(flecha !=null){
                flecha.transform.parent.transform.parent = null;
                flecha.isKinematic = false;
                flecha.AddForce(transform.parent.transform.forward * distanciaValor * 1500, ForceMode.Force);
                distanciaValor=0;
                distancia=0;
                flecha =null;
                
            }
    }
}
