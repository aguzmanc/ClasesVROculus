using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcoMN : MonoBehaviour
{
   
    public List<Renderer> listaRe;
    Rigidbody cuerpo;
    Rigidbody body;
    public Material Magarrado;
    public Material Msuelto;
     public Material Mtocado;
    // Start is called before the first frame update
    void Start()
    {
       
       
         cuerpo=GetComponent<Rigidbody>();
          foreach(Renderer red in listaRe)
        {
            red.material=Msuelto;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tocar()
    {
       foreach(Renderer red in listaRe)
        {
            red.material=Mtocado;
        }
    }
    public void dejarTocar()
    {
          foreach(Renderer red in listaRe)
        {
            red.material=Msuelto;
        }
    }
      public void agarrar(Transform mano)
    {
        foreach(Renderer red in listaRe)
        {
            red.material=Magarrado;
        }
        transform.parent=mano;
        cuerpo.isKinematic=true;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void soltar()
    {
        foreach(Renderer red in listaRe)
        {
            red.material=Msuelto;
        }
       
        transform.parent=null;
        cuerpo.isKinematic=false;
    }
}
