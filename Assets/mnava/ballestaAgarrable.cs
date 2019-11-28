using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballestaAgarrable : MonoBehaviour
{
    public Renderer red;
    Rigidbody cuerpo;
    public Material Magarrado;
    public Material Msuelto;
     public Material Mtocado;
     public Transform origen;
     viroteFisicas viroteClase;
     bool cargada;

    public Transform virote;

    public bool Cargada()
    {
        return cargada;
    }
    // Start is called before the first frame update
    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        red.material=Msuelto;
        cargada=false;
        viroteClase=virote.GetComponent<viroteFisicas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void tocar()
    {
      
            red.material=Mtocado;
       
    }
    public void dejarTocar()
    {
            red.material=Msuelto;
       
    }
      public void agarrar(Transform mano)
    {
        
        red.material=Magarrado;
      
        transform.parent=mano;
        cuerpo.isKinematic=true;

        transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
      
    }   
     public void soltar()
    {
        red.material=Msuelto;
        transform.parent=null;
        cuerpo.isKinematic=false;
    }
    public void disparar()
    {
      if(cargada)
      {
          viroteClase.flechaLanzada();
          cargada=false;
      }
      
    }
    public void recargar()
    {
        if(!cargada)
        {
            viroteClase.tp(origen);
              cargada=true;
        }
    }
}
