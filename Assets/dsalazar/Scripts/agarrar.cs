using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    public Renderer arcoMaterial;
    public Material materialverde;
    public Material materialrojo;


    void Start()
    {
        // arco.transform.SetParent( transform );
       //  Debug.Break();
    }
    void Update()
    {
      //OVRInput.RawAxis1D.RHandTrigger
      if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)>0.7f && tocando==true) {
            arco.transform.SetParent( transform ); //agarra si esta en el area y se ejerce en el handtriger
            arco.GetComponent<Rigidbody>().useGravity=false; //activa la gravedad del arco
            arcoAgarrado=true;
             arcoMaterial.material= materialverde;
            arco.transform.position=new Vector3(transform.position.x+0.0051f,transform.position.y, transform.position.z);
            arco.transform.localPosition=Vector3.zero;
            arco.transform.localRotation= Quaternion.identity;
            arco.GetComponent<Rigidbody>().isKinematic=true;
        }
       if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)<0.7f) {
            arco.transform.parent=null; //suelta el arco cuando no se esta tocando 
            if (arcoAgarrado)
            {
            arco.GetComponent<Rigidbody>().useGravity=true;
             arcoMaterial.material= materialrojo;
            arco.GetComponent<Rigidbody>().isKinematic=false;
             //activa la gravedad del arco
            }
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            arco.transform.parent=null; //suelta el arco, prueba con boton
            arcoAgarrado=false;
            arco.GetComponent<Rigidbody>().useGravity=true;
             arcoMaterial.material= materialrojo;
             //activa la gravedad del arco
        }
         if (Input.GetKey(KeyCode.X) && tocando==true) {
            arco.transform.SetParent( transform ); //agarra mientras esta presionando la tecla y esta dentro del area
            arcoAgarrado=true;
            arco.GetComponent<Rigidbody>().useGravity=false; //activa la gravedad del arco
             arcoMaterial.material= materialverde;
            arco.transform.position=new Vector3(transform.position.x,transform.position.y, transform.position.z+0.7f);
         //   arco.transform.localPosition=Vector3.zero;
            arco.transform.localRotation= Quaternion.identity;
            //arco.transform.position=transform.position;
        }
         if (Input.GetKeyDown(KeyCode.C)) {
            arco.transform.SetParent( transform ); //agarra despues de presionar la tecla
            arcoAgarrado=true;
            arco.GetComponent<Rigidbody>().useGravity=false; //activa la gravedad del arco
             arcoMaterial.material= materialverde;
        }
    }
    public GameObject arco;
    public bool tocando=false;
    public bool arcoAgarrado=false;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="arco")
        {
           // other = GetOtherGameObject();
           // arco.transform.SetParent( transform );
             Debug.Log(other.name);
             tocando=true;
             
           //  arcoMaterial.material= materialverde;
             //arco.GetComponent<Renderer>().material.SetColor("_ SpecColor", Color.red);

          //  other.transform.SetParent( transform, worldPositionStays );
        }
    }
    private void OnTriggerStay(Collider other) {
            
             //arco.GetComponent<Renderer>().material.SetColor("_ SpecColor", Color.red);
             //arcoMaterial.material= materialverde;

    }
    private void OnTriggerExit(Collider other) {
      tocando=false;
     //arco.GetComponent<Renderer>().material.SetColor("_ SpecColor", Color.green);
            // arcoMaterial.material= materialrojo; 
            tocando =false;
      
    }
}
