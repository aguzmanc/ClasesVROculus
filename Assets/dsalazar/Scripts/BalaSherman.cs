using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaSherman : MonoBehaviour
{
    public ParticleSystem particulas;
    public ParticleSystem shock;
    public ParticleSystem fire;
    public ParticleSystem smoke;
     public ParticleSystem fuego;
     public GameObject tanqueTiger;
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
        if (other.gameObject.tag=="Player")
        {

             Debug.Log("llego al sherman"+other.name);
            smoke.Play();   
            other.GetComponent<Vida>().vida=other.GetComponent<Vida>().vida-5;
        }
            Destroy(gameObject, 1);

    }
      void DestroyObjectDelayed()
    {
        Destroy(gameObject, 3);
    }
}
