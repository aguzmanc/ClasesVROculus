using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDosManos : MonoBehaviour
{
    bool sostenida;
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
         sostenida=false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(sostenida==false)
        {
            transform.parent=null;
            cuerpo.isKinematic=false;

        }
        
    }
    public void tocar()
    {
        indicador.material=EstadoTocado;
       
    }
    public void dejarTocar()
    {
        indicador.material=EstadoSuelto;
          apoyo.SetActive(false);
          sostenida=false;
       
    }
     public void tocarAp()
    {
        apoyoRender.material=EstadoTocado;
       
    }
    public void dejarTocarAp()
    {
        apoyoRender.material=EstadoSuelto;
        sostenida=false;
        indicador.material=EstadoSuelto;
        transform.parent=null;
        cuerpo.isKinematic=false;
       
       
    }
     public void agarrarAp()
    {
        sostenida=true;
       
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
        indicador.material=EstadoSuelto;
          apoyoRender.material=EstadoSuelto;
        transform.parent=null;
        cuerpo.isKinematic=false;
        apoyo.SetActive(false);
          sostenida=false;
    }
    public void agarrar(Transform mano)
    {
 
        indicador.material=EstadoAgarrado;
       
        apoyo.SetActive(true);

        
    }
    public void AgarrarFull(Transform papa)
    {
        transform.parent=papa;
        cuerpo.isKinematic=true;
        transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
    }
    public bool dosmanos()
    {
        return sostenida;
        
    }
}
