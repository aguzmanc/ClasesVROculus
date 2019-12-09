using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaAmarilla : MonoBehaviour
{
    public Renderer agarrador;
    Rigidbody cuerpo;
    public Material agarrado;
    public Material suelto;
     public Material tocado;
     public Transform origen;
     bool cargada;

    public Transform flecha;

    public bool Cargada()
    {
        return cargada;
    }

    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        agarrador.material=suelto;
        cargada=false;
    }
    
      public void tocar()
    {
      
        agarrador.material=tocado;
       
    }
    public void dejarTocar()
    {
        agarrador.material=suelto;
       
    }
      public void agarrar(Transform mano)
    {
        
        agarrador.material=agarrado;
      
        transform.parent=mano;
        cuerpo.isKinematic=true;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
      
    }   
     public void soltar()
    {
        agarrador.material=suelto;
        transform.parent=null;
        cuerpo.isKinematic=false;
    }
    public void disparar()
    {
      if(cargada)
      {
          cargada=false;
      }
      
    }
    public void recargar()
    {
        if(!cargada)
        {
            cargada=true;
        }
    }
}

