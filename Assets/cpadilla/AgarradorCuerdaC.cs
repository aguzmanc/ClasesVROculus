using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdaC : MonoBehaviour
{
     const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;
    public bool estaAgarrando;


    public float distancia;
    public bool tocando;
    public Transform pivotCuerda;
    public CuerdaC cuerdac;
    public GameObject flechaPrefab;
    public Transform arrowSpan;
    public float shootForce=20f;
    public Rigidbody rb;


    void Start()
    {
        tocando = false;
        estaAgarrando = false;
        
    }

    void Update()
    {
        if(estaAgarrando) {
            distancia = Vector3.Distance(transform.position, pivotCuerda.position);
            distancia = Mathf.Max(0f, distancia);
            distancia = Mathf.Min(0.3f, distancia);
            Debug.DrawLine(transform.position, pivotCuerda.position, Color.green);

        } else{
            distancia = 0;
        }

        if(cuerdac!=null)
            cuerdac.transform.localPosition = new Vector3(0,0,distancia);

        bool cambio = UpdateNivelAgarre();
        
        if(estaAgarrando && cambio) {
            if(cuerdac != null)
                cuerdac.Agarrar();   
        }

        if(estaAgarrando==false && cuerdac!=null){
            if(cuerdac!=null)
                cuerdac.Soltar();
                if(flechaPrefab!=null && cambio)
                {
                    Instantiate(flechaPrefab,arrowSpan.position,Quaternion.identity);            
                    rb.velocity=transform.forward*shootForce;
                }
                
        }
        
    }


    bool UpdateNivelAgarre(){
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
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
