using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDosManos : MonoBehaviour
{
    public GameObject apoyo;
    public Renderer apoyoRender;
    public Renderer indicador;
    Rigidbody cuerpo;

    public Material EstadoAgarrado;
    public Material EstadoSuelto;
    public Material EstadoTocado;
    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        indicador.material=EstadoSuelto;
         apoyoRender.material=EstadoSuelto;
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
     public void tocarAp()
    {
        apoyoRender.material=EstadoTocado;
       
    }
    public void dejarTocarAp()
    {
        apoyoRender.material=EstadoSuelto;
       
    }
    public void agarrarBase()
    {
 
        indicador.material=EstadoAgarrado;
        //transform.parent=mano;
        //cuerpo.isKinematic=true;
        //transform.localPosition = Vector3.zero;
        //transform.localRotation =Quaternion.identity;
        apoyo.SetActive(true);
        
    }   
    public void soltar()
    {
        //indicador.material=EstadoSuelto;
        //transform.parent=null;
        //cuerpo.isKinematic=false;
    }
    public void agarrar(Transform mano)
    {
 
        indicador.material=EstadoAgarrado;
        //transform.parent=mano;
        //cuerpo.isKinematic=true;
        //transform.localPosition = Vector3.zero;
        //transform.localRotation =Quaternion.identity;
        apoyo.SetActive(true);
        
    }
}
