using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaC : MonoBehaviour
{
    public Renderer rend;
    public Material materialSuelto;
    public Material materialTocado;
    public Material materialAgarrando;

    // Start is called before the first frame update
    void Start()
    {
          rend.material = materialSuelto;
    }

    // Update is called once per frame
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
    } 
    
}
