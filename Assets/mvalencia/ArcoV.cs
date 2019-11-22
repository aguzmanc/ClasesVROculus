using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoV : MonoBehaviour
{
    public Renderer rend;

    public GameObject cuerda;
    Rigidbody body;


    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend.material = materialSuelto;
        cuerda = transform.Find("pivot").gameObject;
        cuerda.SetActive(false);
    }



    public void Tocar()
    {
        rend.material = materialTocado;
    }


    public void DejarDeTocar()
    {
        rend.material = materialSuelto;
    }


    public void Agarrar(Transform agarrador)
    {   
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        cuerda.SetActive(true);
    }


    public void Soltar()
    {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;

        cuerda.SetActive(false);
    }
}
