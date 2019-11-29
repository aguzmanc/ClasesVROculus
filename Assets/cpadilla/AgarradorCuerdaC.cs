using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdaC : MonoBehaviour
{
    public Transform pivotCuerda;
    public CuerdaC cuerdac;
    Rigidbody flecha;
     const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;
    public bool estaAgarrando;
    bool cambio;
    float actual;
    public float distanciaValor;
    public float distancia;
    public bool tocando;
    public bool sepuedeDisparar=false;
    


    void Start()
    {
        
    }

    void Update()
    {
        if(estaAgarrando) {
            distancia = Vector3.Distance(transform.position, pivotCuerda.position);
            distancia = Mathf.Max(0f, distancia);
            distancia = Mathf.Min(0.3f, distancia);
            Debug.DrawLine(transform.position, pivotCuerda.position, Color.green);
            distanciaValor = distancia;
        } else{
            distancia = 0;
        }

        if(cuerdac!=null){
            cuerdac.transform.localPosition = new Vector3(0,0,distancia);
            if(distancia>0.15f && flecha==null && sepuedeDisparar){
                sepuedeDisparar=false;
                flecha = cuerdac.bala();
            }
        }
        cambio = UpdateNivelAgarre();
        cambio=true;
        if(estaAgarrando && cambio) {
            if(cuerdac != null)
                cuerdac.Agarrar();   
        }

        if(estaAgarrando==false && cuerdac!=null){
            if(cuerdac!=null)
                cuerdac.Soltar();
                sepuedeDisparar=true;
            if (flecha!=null)
            {
                sepuedeDisparar=false;
                flecha.transform.parent.transform.parent=null;
                flecha.isKinematic=false;
                flecha.AddForce(transform.parent.transform.forward*distanciaValor*1000,ForceMode.Force);

                flecha=null;
            }
                
        }
        
    }


    bool UpdateNivelAgarre(){
         actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool limiteTraspasado = false;

        if(agarre < LIMITE_AGARRE  && actual >= LIMITE_AGARRE){
            estaAgarrando = true;
            limiteTraspasado = true;
        }

        if(agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR){
            estaAgarrando = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Cuerda"){
            cuerdac = other.GetComponent<CuerdaC>();
            cuerdac.Tocar();
            tocando = true;
            pivotCuerda = cuerdac.transform.parent;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Cuerda"){
            cuerdac = other.GetComponent<CuerdaC>();
            cuerdac.DejarDeTocar();
            tocando = false;
        }
    }
}
