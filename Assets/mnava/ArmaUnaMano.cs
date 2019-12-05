using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaUnaMano : MonoBehaviour
{
    public Renderer indicador;
    Rigidbody cuerpo;

    public Material EstadoAgarrado;
    public Material EstadoSuelto;
    public Material EstadoTocado;
    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        indicador.material=EstadoSuelto;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void tocar()
    {
        indicador.material=EstadoTocado;
       
    }
    public void dejarTocar()
    {
        indicador.material=EstadoSuelto;
       
    }
    public void agarrar(Transform mano)
    {
 
        indicador.material=EstadoAgarrado;
        transform.parent=mano;
        cuerpo.isKinematic=true;
        transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
        
    }   
    public void soltar()
    {
        indicador.material=EstadoSuelto;
        transform.parent=null;
        cuerpo.isKinematic=false;
    }
}
