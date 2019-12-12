using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hongo : MonoBehaviour
{
    public puntaje puntaje;
    bool subir;
    bool bajar;
    Vector3 arriba;
    Vector3 original;
    public AudioClip golpe;
    public AudioClip salto;


    public IniciarJuego iniciarJuego;
    void Start()
    {
        iniciarJuego = GameObject.Find("Boton_Inicio").GetComponent<IniciarJuego>();
        puntaje = GameObject.Find("marcadores").GetComponent<puntaje>();
        original = transform.position;
        arriba = new Vector3(transform.position.x, transform.position.y+0.4f, transform.position.z);
        subir=false;
        bajar=false;
        puntaje.AumentarNEnemigos();
        StartCoroutine(SubirBajar());
    }
    void Update() {
        if (subir)
            SubirHongo();
        if (bajar)
            BajarHongo();
    }

     IEnumerator SubirBajar()
    {   
        while(true){
            yield return new WaitForSeconds(Random.RandomRange(1,2));
            subir=true;
            bajar=false;
            transform.GetComponent<AudioSource>().PlayOneShot(salto, 4f);
            yield return new WaitForSeconds(Random.RandomRange(1,2));
            subir=false;
            bajar=true;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Destruir());

        }

    }
    void SubirHongo(){
        transform.position = Vector3.Lerp(transform.position, arriba, 0.1f);
    }
    void BajarHongo(){
        transform.position = Vector3.Lerp(transform.position, original, 0.15f);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.name=="bate" || other.name=="martillo")
        {
            if (other.GetComponentInChildren<bate>().golpear)
			{
                other.GetComponentInChildren<bate>().NoGolpear();
                StopAllCoroutines();
                subir=false;
                bajar=true;
                puntaje.GolpeEjecutado(true);
                transform.GetComponent<AudioSource>().PlayOneShot(golpe, 1f);
				other.GetComponentInChildren<bate>().golpear=false;
                StartCoroutine(Destruir());
			}
        }
    }
    IEnumerator Destruir()
    {   
        while(true){
            iniciarJuego.Remover(transform);
            yield return new WaitForSeconds(1f);
            Destroy(transform.gameObject);
        }

    }
}
