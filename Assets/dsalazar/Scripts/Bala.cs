using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public ParticleSystem particulas;
    public ParticleSystem shock;
    public ParticleSystem fire;
    public ParticleSystem smoke;
     public ParticleSystem fuego;
    void Start()
    {
      particulas.Play();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="sherman")
        {
            shock.Play();
            fire.Play();  
            smoke.Play();   
            fuego.Play();
            //other.GetComponent<MuerteTanque>().Morir();
            transform.position=other.transform.position ;
           // Destroy(other.gameObject);
        }
    }
}
