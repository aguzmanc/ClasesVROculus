using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanza : MonoBehaviour
{
    public Renderer indicador;
    Rigidbody cuerpo;

    public Material EstadoAgarrado;
    public Material EstadoSuelto;
    public Material EstadoTocado;

    Vector3 velocidadVectorial;


    public List<Vector3> posiciones;
    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        indicador.material=EstadoSuelto;
        posiciones=new List<Vector3>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(posiciones.Count==4)
        {
            posiciones.RemoveAt(0);

        }
        posiciones.Add(transform.position);
        Vector3 vector=new Vector3();
        for (byte i=0; i<posiciones.Count; i++) 
        {
            vector=vector+posiciones[i];
        }
        velocidadVectorial=vector/posiciones.Count;

        Debug.Log(velocidadVectorial);


        
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

        cuerpo.AddForce(velocidadVectorial);
    }
}
