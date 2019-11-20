using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrador_izquierda : MonoBehaviour
{
    const float LIMITE_AGARRE=0.7F;
    const float LIMITE_SOLTAR = 0.3F;
    [Range(0f,1f)]
    public float agarre;

    public arcosc arco;

    public bool estaAgarrando;

    private void Start() {
        estaAgarrando=false;
    }

    private void Update() {
        bool cambio = ActualizarNivelAgarre();

        if (estaAgarrando && arco !=null && cambio)
        {
            arco.Agarrar(transform);
        }

        if (estaAgarrando == false && cambio && arco !=null)
        {
            arco.Soltar2();
        }
      
    }

    bool ActualizarNivelAgarre()
    {
        bool limiteTraspasado = false;
        float actual =  OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
        if (agarre<LIMITE_AGARRE && actual >=LIMITE_SOLTAR)
        {
            estaAgarrando=true;
            limiteTraspasado = true;
        }
        if (agarre > LIMITE_SOLTAR && actual <= LIMITE_SOLTAR)
        {
            estaAgarrando=false;
            limiteTraspasado= true;
        }
     
        agarre=actual;

        return limiteTraspasado;
    }



    private void OnTriggerEnter(Collider other)
     {
        arcosc arcoAgarrado = other.GetComponent<arcosc>();
        if (arcoAgarrado==null)
        {   arco = arcoAgarrado;
            arco.Tocar();
        }
    }

    private void OnTriggerExit(Collider other) {
        arcosc arcoAgarrado = other.GetComponent<arcosc>();
        if (arcoAgarrado==null)
        {

            arco.Soltar();
            arco = null;
        }
    }
 
}
