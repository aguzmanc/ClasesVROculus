using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarRPalanca : MonoBehaviour
{
      public Renderer rPalancaRender;
    public Material materialverde;
    public Material materialrojo;
    public GameObject rPalanca;
    public bool tocandoRpalanca=false;
    public bool RpalancaAgarrado=false;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)>0.7f && tocandoRpalanca==true) {
            rPalanca.transform.SetParent( transform ); 
           // rPalanca.GetComponent<Rigidbody>().useGravity=false; 
            RpalancaAgarrado=true;
             rPalancaRender.material= materialverde;
            //rPalanca.transform.position=new Vector3(transform.position.x+0.0051f,transform.position.y, transform.position.z);
            rPalanca.transform.position=new Vector3(transform.position.x,transform.position.y, transform.position.z);
            rPalanca.transform.localPosition=Vector3.zero;
            rPalanca.transform.localRotation= Quaternion.identity;
            rPalanca.GetComponent<Rigidbody>().isKinematic=true;
        }
       if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)<0.7f) {
          //  rPalanca.transform.parent=null; 
            if (RpalancaAgarrado)
            {
             rPalancaRender.material= materialrojo;
            }
        }
    }
      private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Rpalanca")
        {
             Debug.Log(other.name);
             tocandoRpalanca=true;
        }
    }
}
