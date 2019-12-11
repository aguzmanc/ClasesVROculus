using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador : MonoBehaviour
{

    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f,1f)]
    public float agarre;
    public Bola bola;

    public Bola aux;

    public bool estaAgarrando;

     private Vector3 _currentGrabbedLocation;

    // Start is called before the first frame update
    void Start()
    {
         estaAgarrando=false;
        _currentGrabbedLocation = new Vector3();
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
        bola.Impulso(gameObject.transform.forward);
        bola.Soltar();
        //gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 1); 
         //f.GetComponent<Rigidbody>().AddForce(arco.transform.forward*speed*2);
         Rigidbody rigidBody = bola.GetComponent<Rigidbody>();
        Vector3 throwVector =  bola.transform.position - _currentGrabbedLocation; // Get the direction that we're throwing
            rigidBody.AddForce(throwVector * 10, ForceMode.Impulse); // Throws the ball by sending a force
            bola = null;
           Debug.Log("el metodo ocurre antes left");
      }

      if(OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.O))
      {
          
        aux.transform.position=new Vector3(0.348f, 0, 0.097f);
      }
    }


    bool UpdateNivelAgarre()
    {
        bool limiteTraspasado=false;
        float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
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
            Debug.Log("trigger antes left");
           bola.DejarDeTocar();
          
          // bola =null;
       }
    }



}
