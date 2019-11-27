using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdaW : MonoBehaviour
{
    Transform pivotCuerda;
    Rigidbody flecha;
        const float limite_agarre =0.7f;
    const float limite_soltar =0.3f;
    CuerdaW cuerda;
    
    [Range(0,1)]
       public float agarre ;
    bool cambio;
    public bool estaagarrando;
    float actual;
    public float distancia;
     public float distanciaValor;
    public bool tocado;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cuerda!=null){
           flecha = cuerda.proyectil();
        }
        if(estaagarrando){
            distancia = Vector3.Distance(transform.position,pivotCuerda.position);
            distancia = Mathf.Max(0f,distancia);
            distancia  = Mathf.Min(0.3f,distancia);
            Debug.DrawLine(transform.position,pivotCuerda.position,Color.green);
            Debug.Log(distancia + "distancia1");
            distanciaValor = distancia;
        }
        else {
            distancia =0;
        }
        if(cuerda!=null){
            cuerda.transform.localPosition =new Vector3(0,0,distancia);
            
            if(distancia>0.15f && flecha==null){
                flecha = cuerda.proyectil();
            }
        }


         cambio= UpdateNivelAgarreDerecha();
        cambio=true;
            if(estaagarrando  && cambio){
            if(cuerda!=null)
            cuerda.Agarrar();
        }
        if(!estaagarrando && cambio ){
            if(cuerda!=null)
            cuerda.Soltar();
            if(flecha !=null){
                flecha.transform.parent.transform.parent = null;
                flecha.isKinematic = false;
                flecha.AddForce(transform.parent.transform.forward * distanciaValor * 1000, ForceMode.Force);
                flecha =null;
            }
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
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Cuerda"){
            Debug.Log("Tocar Cuerda");
            cuerda =  other.transform.GetComponent<CuerdaW>();

            cuerda.Tocar();
            tocado=true;
            pivotCuerda = cuerda.transform.parent;
           /*  Cuerda cuerda =other.GetComponent<Cuerda>();
            cuerda.Tocar();*/
        }
    }
    private void OnTriggerExit(Collider other) {
         if(other.tag=="Cuerda"){
             Debug.Log("Dejar de Tocar Cuerda");
            cuerda =  other.transform.GetComponent<CuerdaW>();
            cuerda.DejarTocar();
           // cuerda=null;
           tocado=false;
           /* Cuerda cuerda =other.GetComponent<Cuerda>();
            cuerda.DejarTocar();*/
        }
    }

 
}
