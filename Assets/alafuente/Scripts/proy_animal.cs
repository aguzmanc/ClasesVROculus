using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proy_animal : MonoBehaviour
{
    public Renderer rend;
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto; 


    void Start()
    {
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
        
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }


    public void Soltar() {
        transform.parent = null;
        rend.material = materialTocado;
    }

}
