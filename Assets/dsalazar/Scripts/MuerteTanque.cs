using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteTanque : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particulasFuego;
    void Start()
    {
        //FlamesParticleEffect
        // particulasFuego.GetComponent<ParticleSystem>().=true;
        Morir();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Morir(){
        particulasFuego.Play();
    }

}
