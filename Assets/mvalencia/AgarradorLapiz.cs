using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorLapiz : MonoBehaviour
{
    const float LIMITE_AGARRE = 0.7f;
    const float LIMITE_SOLTAR = 0.3f;

    [Range(0f, 1f)]
    public float agarre;

    public bool estaAgarrando;

    public Lapiz lapiz;
    public GameObject dibujo;
    

    void Start()
    {
        estaAgarrando = false;
    }

    void Update()
    {
        bool cambio = UpdateNivelAgarre();

        if (estaAgarrando && lapiz != null && cambio)
        {
            lapiz.Agarrar(transform);
            dibujo.SetActive(true);
            
        }

        if (estaAgarrando == false && cambio && lapiz != null)
        {
            lapiz.Soltar();
            dibujo.SetActive(false);
        }
    }
    bool UpdateNivelAgarre()
    {
        float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        bool limiteTraspasado = false;

        if (agarre < LIMITE_AGARRE && actual >= LIMITE_AGARRE)
        {
            estaAgarrando = true;
            limiteTraspasado = true;
        }

        if (agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
        {
            estaAgarrando = false;
            limiteTraspasado = true;
        }

        agarre = actual;

        return limiteTraspasado;
    }



    void OnTriggerEnter(Collider otro)
    {
        Lapiz lapizAgarrado = otro.GetComponent<Lapiz>();

        if (lapizAgarrado != null)
        {
            lapiz = lapizAgarrado;
         
        }
    }


    void OnTriggerExit(Collider otro)
    {
        Lapiz lapizAgarrado = otro.GetComponent<Lapiz>();
        if (lapizAgarrado != null)
        {
           
            lapiz = null;
        }
    }
}
