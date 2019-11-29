using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCuerda : MonoBehaviour
{
    public bool cuerdaArea=false;
    public GameObject cuerda;
    public Renderer cuerdaMaterial;
    public Material materialVerde;
    public Material materialrojo;
    public GameObject baseArco;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)>0.7f && cuerdaArea==true) {
            
            cuerda.transform.SetParent( transform ); //agarra si esta en el area y se ejerce en el handtriger
             cuerdaMaterial.material= materialVerde;
             cuerda.transform.position=transform.position;             

        }
       if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)<0.7f) {
            //cuerda.transform.parent=null; //suelta el arco cuando no se esta tocando 
             cuerdaMaterial.material= materialrojo;
            cuerda.transform.position= new Vector3(baseArco.transform.position.x,baseArco.transform.position.y,baseArco.transform.position.z-0.5f);
        }
         if (Input.GetKeyDown(KeyCode.V)&& cuerdaArea==true) {
             cuerda.transform.SetParent( transform ); //agarra si esta en el area y se ejerce en el handtriger
             cuerdaMaterial.material= materialVerde;
             cuerda.transform.position=transform.position;
        }
        else
        {
             cuerdaMaterial.material= materialrojo;
            cuerda.transform.position= new Vector3(baseArco.transform.position.x,baseArco.transform.position.y,baseArco.transform.position.z-0.5f);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="cuerda")
        {
            cuerdaArea=true;
        }
    }
      private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag=="cuerda")
        {
            cuerdaArea=true;
        }
    }
      private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag=="cuerda")
        {
            cuerdaArea=false;
        }
    }
}
