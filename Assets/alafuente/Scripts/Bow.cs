using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Renderer rend;

    public GameObject cuerda;


    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto; 


    void Start()
    {
        rend.material = materialSuelto;
        cuerda = GameObject.Find("Cuerda");
        if(cuerda!=null)
        {
            Debug.Log("asd");
        }
        else{
            Debug.Log("nulo");

        }
        cuerda.SetActive(false);
    }



    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }


    public void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        cuerda.SetActive(true);
    }


    public void Soltar() {
        transform.parent = null;
        rend.material = materialTocado;

        cuerda.SetActive(false);
    }

}
