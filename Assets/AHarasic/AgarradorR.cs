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

//https://codingchronicles.com/unity-vr-development/day-66-of-100-days-of-vr-picking-up-and-throwing-objects-in-unity-part-1
    private Vector3 _currentGrabbedLocation;
    // Start is called before the first frame update
    void Start()
    {
         estaAgarrando=false;
         _currentGrabbedLocation = new Vector3();
    }

    float time=10f;
    // Update is called once per frame
    void Update()
    {
    bool cambio = UpdateNivelAgarre();
      //if (bola != null)
       // {
      //      _currentGrabbedLocation = bola.transform.position;

      //  }

      if(estaAgarrando && bola!=null && cambio)
      {
            bola.Agarrar(transform);
      }
      if(estaAgarrando==false && cambio && bola!=null)
      {
        bola.Soltar();
        Rigidbody rigidBody = bola.GetComponent<Rigidbody>();
        Vector3 throwVector =  bola.transform.position - _currentGrabbedLocation; // Get the direction that we're throwing
            rigidBody.AddForce(throwVector * 10, ForceMode.Impulse); // Throws the ball by sending a force
            bola = null;
           Debug.Log("el metodo ocurre antes");

      }
        if(OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.P))
      {
         // Debug.Log("2siuu");
        aux.transform.position=new Vector3(0.348f, -0.425f, -0.041f);
      }


   //  time -= Time.deltaTime;
  //   if ( time < 0 )
   //  {
          //Debug.Log("2siuu");
         // borrarEsto=false;
          //aggarreBorrar=0.1f;
    // }

    }

  //public bool borrarEsto=true;
  // [Range(0f,1f)]
  //public float aggarreBorrar=0.1f;
    bool UpdateNivelAgarre()
    {
       // bool limiteTraspasado=borrarEsto;
         bool limiteTraspasado=false;
       float actual=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
        //float actual=aggarreBorrar;
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
           Debug.Log("trigger antes");
           bola.DejarDeTocar();
          // bola =null;
       }
    }



}
