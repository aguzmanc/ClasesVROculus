using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{

    public Material noStatus;
    public Material taken;
    public Material canTake;

    public Renderer rend;
    Rigidbody body;
    AudioSource audioSource;
    public AudioClip disparo;

    int contDisparos=0;
    int cargador=8;
    bool cargada=true;



    public Material descargadaMat;
    public Material cargadaMat;
    public Renderer charSlot;


    public Transform lanzaCargador;
    public GameObject prefabCargadorVacio;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend.material = noStatus;
        audioSource = GetComponent<AudioSource>();
        charSlot.material=cargadaMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tocar() {
        rend.material = canTake;
    }


    public void DejarDeTocar() {
        rend.material = noStatus;
    }

    public void Agarrar(Transform mano) { 
        rend.material = taken;
        body.isKinematic = true;
        body.useGravity= false;
        transform.parent = mano;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        
    }

    public void Soltar() {
        transform.parent = null;
        rend.material = canTake;
        body.isKinematic = false;
        body.useGravity=true;
        
    }

    public void Disparar(){
        if (contDisparos<=cargador && cargada)
        {
            audioSource.PlayOneShot(disparo);
            contDisparos++;
        }
        if (contDisparos==cargador)
        {
            cargada=false;
            contDisparos=0;
            charSlot.material=descargadaMat;

            GameObject cargVacio=Instantiate(prefabCargadorVacio,lanzaCargador.transform.position,lanzaCargador.transform.rotation);            
            cargVacio.transform.forward=lanzaCargador.transform.forward;

        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cargador"))
        {
            cargada=true;
            contDisparos=0;
            charSlot.material=cargadaMat;
        }
    }
}
