using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCuerdab : MonoBehaviour
{
    

    const float LIMITE_AGARRE=0.7F;
    const float LIMITE_SOLTAR = 0.3F;
    [Range(0f,1f)]
    public float agarre;

    public bool estaAgarrando;
    public float distancia;
    public bool tocando;
    public Transform pivotCuerda;

    public Cuerda cuerdab;

    public Flechag flechag;

    public  bool suelta;
    // Start is called before the first frame update
    void Start()
    {
        tocando=false;
        estaAgarrando=false;

    }

 bool ActualizarNivelAgarre()

    {
        bool limiteTraspasado = false;
        float actual =  OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
        if (agarre<LIMITE_AGARRE && actual >=LIMITE_SOLTAR)
        {
            estaAgarrando=true;
            suelta=false;
            limiteTraspasado = true;
        }
        if (agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
        {
            estaAgarrando=false;
            suelta=true;
            limiteTraspasado= true;
        }
     
        agarre=actual;

        return limiteTraspasado;
    }
    // Update is called once per frame
    void Update()
    {
       
             
        
        if (tocando)
        {
           distancia =  Vector3.Distance(transform.position,pivotCuerda.position);
           distancia = Mathf.Max(0f,distancia);
           distancia = Mathf.Min(0.3f,distancia);
        }
        else{
            
            distancia=0;
        }
        if (cuerdab!=null)
        {
        cuerdab.transform.localPosition = new Vector3(0,0,distancia);
           

           
           
        }
         
        bool cambio = ActualizarNivelAgarre();

        if (estaAgarrando &&  cambio)
        {
            if (cuerdab !=null)
            {
            cuerdab.Agarrar();
                
            }
        }

        if (estaAgarrando == false && cuerdab !=null )
        {
            if ( cuerdab !=null)
            {
            cuerdab.Soltar();
                    if (suelta && estaAgarrando == false)
                    {
                        flechag.disparar=true;
                    }
                    else
                    {
                        flechag.disparar=false;
                    }

            }
        }
    }

    private void OnTriggerEnter(Collider other) {
       
        if (other.tag == "Cuerda")
        {
            cuerdab = other.GetComponent<Cuerda>();
            cuerdab.Tocar();
            tocando = true;
            pivotCuerda = cuerdab.transform.parent;
          
        }
    }

    private void OnTriggerExit(Collider other) {
        
           if (other.tag == "Cuerda")
        {
            cuerdab = other.GetComponent<Cuerda>();
            cuerdab.DejarDeTocar();
            //cuerdab=null;            
            tocando = false;
           
             //pivotCuerda = null;
        }
    }
}
