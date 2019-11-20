using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arco : MonoBehaviour
{
    Renderer render;

    public Material matSuelto;
    public Material matTocado;
    public Material matAgarrado;
    void Start()
    {
        render = GetComponent<Renderer>();
        render.material= matSuelto;
    }
    public void Tocar(){
        render.material = matTocado;
    }
    public void DejarTocar(){
        render.material =matSuelto;
    }
}
