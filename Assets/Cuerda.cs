using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    public Renderer rend;

    public Material materialSuelto;
    public Material materialTocado;
    public Material materialAgarrando;

    public GameObject preview;


    void Start()
    {
        rend.material = materialSuelto;
    }


    void Update()
    {
       
    }


    public void Tocar(){
        rend.material = materialTocado;
    }

    public void DejarDeTocar(){
        rend.material = materialSuelto;
    }       


    public void Agarrar(){
        rend.material = materialAgarrando;
       // preview.GetComponent()<Renderer>.enabled = true/false
       preview.SetActive(true);
    }


    public void Soltar(){
        rend.material = materialTocado;
        preview.SetActive(false);
        //Debug.Log("SOLTADO!!!");
    } 

}
