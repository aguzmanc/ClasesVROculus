using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerda : MonoBehaviour
{
    public Renderer rend;

    public Material materialSuelto;
    public Material materialTocado;
    public Material materialAgarrando;


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

}
