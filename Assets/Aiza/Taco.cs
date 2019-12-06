using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taco : MonoBehaviour
{
    Rigidbody bodyTaco;
    Renderer rendTaco;
    public Material materialTocado;

    public Material materialAgarrado;
    public Material materialSuelto;
    // Start is called before the first frame update
    void Start()
    {
        bodyTaco = GetComponent<Rigidbody>();
        rendTaco  = GetComponent<Renderer>();
        rendTaco.material = materialSuelto;
        
    }

    // Update is called once per frame


    public void Tocar()
    {
        rendTaco.material = materialTocado;
         
    }

    public void Agarrar(Transform agarrador)
    {
        rendTaco.material = materialAgarrado;
        bodyTaco.isKinematic=true;
        transform.parent = agarrador;

        //transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(90,0,0);
    }

     public void DejarDeTocar()
    {
         rendTaco.material = materialSuelto;
    }

     public void Soltar()
    {
         transform.parent=null;
         rendTaco.material = materialTocado;
         bodyTaco.isKinematic = false; //debatir porq lo soltare y quiero q siga vertical
    }
}
