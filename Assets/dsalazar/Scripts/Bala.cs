using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.Animations;

public class Bala : MonoBehaviour
{
    public ParticleSystem particulas;
    public ParticleSystem shock;
    public ParticleSystem fire;
    public ParticleSystem smoke;
     public ParticleSystem fuego;
     public GameObject tanqueSherman;
    void Start()
    {
      particulas.Play();  
      DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("llego trigger"+other.name);
        if (other.gameObject.tag=="sherman")
        {

             Debug.Log("llego al sherman"+other.name);
           // shock.Play();
           // fire.Play();  
            smoke.Play();   
           // fuego.Play();
            other.GetComponent<MuerteTanque>().enabled=true;
            other.GetComponent<PatoGuardian>().enabled=false;
            other.GetComponent<Perseguidor>().enabled=false;
            other.GetComponent<LookAtConstraint>().enabled=false;
            other.GetComponent<Rigidbody>().isKinematic=true;
            
           // transform.position=other.transform.position ;
           // gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }
            Destroy(gameObject, 1);

    }
      void DestroyObjectDelayed()
    {
        Destroy(gameObject, 3);
    }
}
