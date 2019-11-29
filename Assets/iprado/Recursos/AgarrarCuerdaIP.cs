using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCuerdaIP : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

   [Range(0f, 1f)]
    public float agarre;
    public bool estaAgarrando;


    public float distancia;
    public bool tocando;
    public Transform pivotCuerda;
    public CuerdaIP cuerda;

    public bool agarrar=false;
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

        if(cuerda!=null)
            cuerda.transform.localPosition = new Vector3(0,0,-distancia);






        bool cambio = UpdateNivelAgarre();
        
        if(estaAgarrando && cambio) {
            if(cuerda != null)
                cuerda.Agarrar();   
        }

        if(estaAgarrando==false && cuerda!=null){
            if(cuerda!=null)
                cuerda.Soltar();
        }
        
        // if (agarrar)
        // {
        //     if(cuerda != null)
        //         cuerda.Agarrar(); 
        // }
        // if (!agarrar)
        // {
        //      if(cuerda!=null)
        //         cuerda.Soltar();
        // }
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
        if(other.tag == "cuerda"){
            cuerda = other.GetComponent<CuerdaIP>();
            cuerda.Tocar();
            tocando = true;
            pivotCuerda = cuerda.transform.parent;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "cuerda"){
            cuerda = other.GetComponent<CuerdaIP>();
            cuerda.DejarDeTocar();
            //cuerda = null;
            tocando = false;
            //pivotCuerda = null;
        }
    }
}
