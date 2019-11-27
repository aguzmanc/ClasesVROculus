using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaE : MonoBehaviour
{
    public Renderer rend;
    public GameObject flecha;

    AgarradorCuerdaE e;

    public Material materialSuelto;
    public Material materialTocado;
    public Material materialAgarrando;


    void Start()
    {
        rend.material = materialSuelto;
        e = FindObjectOfType<AgarradorCuerdaE>();
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
    }


    public void Soltar(){
        rend.material = materialTocado;
        Disparar();
    } 

    public void Disparar(){
        GameObject newFlecha = (GameObject) Instantiate(flecha);
        newFlecha.transform.position = transform.position;
        //newFlecha.GetComponent<Flecha>().fuerza = 10f;
    }

}
