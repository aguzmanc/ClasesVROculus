using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public float vida=100;
    public ParticleSystem fuegoParticulas;
    public AudioSource fuego;
    public TextMesh vidaTexto;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida<1)
        {
            fuego.Play();
            fuegoParticulas.Play();
        vidaTexto.text="Vida: 0";
        SceneManager.LoadScene("Wittmann");
        }
        else
        {
        vidaTexto.text="Vida: "+vida.ToString();
            
        }
    }
}
