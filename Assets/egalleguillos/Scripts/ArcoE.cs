using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoE : MonoBehaviour
{
    public Renderer rend;

    Rigidbody body;

    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto; 

    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend.material = materialSuelto;
    }

    public void Tocar() {
        rend.material = materialTocado;
    }

    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Soltar() {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }
}

