using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorR : MonoBehaviour
{

    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f,1f)]
    public float agarre;
    public Bola bola;

    public Bola aux;

    public bool estaAgarrando;

    // Start is called before the first frame update
    void Start()
    {
         estaAgarrando=false;
    }

    // Update is called once per frame
    void Update()
    {
    bool cambio = UpdateNivelAgarre();

      if(estaAgarrando && bola!=null && cambio)
      {
            bola.Agarrar(transform);
      }
      if(estaAgarrando==false && cambio && bola!=null)
      {
        bola.Soltar();
      }
        if(OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.P))
      {
          
        aux.transform.position=new Vector3(0.348f, 0, -0.041f);
      }

    }


    bool UpdateNivelAgarre()
    {
        bool limiteTraspasado=false;
        float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
        //float actual=0.8f;
    if( agarre<LIMITE_AGARRE && actual>=LIMITE_AGARRE)
    {
            estaAgarrando=true;
            limiteTraspasado=true;
    }
            if(agarre>LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
            {
                estaAgarrando=false;
                limiteTraspasado=true;
                
            }
            agarre=actual;
            //Debug.Log(actual);
        return limiteTraspasado;
        
    }


    private void OnTriggerEnter(Collider other) {
       Bola bolaAgarrada = other.GetComponent<Bola>();
       if(bolaAgarrada!=null)
       {
           bola=bolaAgarrada;
           bola.Tocar();
       }
       // Debug.Log(other.name);
    }


     private void OnTriggerExit(Collider other) {
         Bola bolaAgarrada = other.GetComponent<Bola>();
         if(bolaAgarrada!=null)
       {
           
           bola.DejarDeTocar();
           bola =null;
       }
    }



}
