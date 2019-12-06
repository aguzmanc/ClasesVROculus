using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarLPalanca : MonoBehaviour
{
   public Renderer lPalancaRender;
    public Material materialverde;
    public Material materialrojo;
    public GameObject lPalanca;
    public bool tocandoLpalanca=false;
    public bool LpalancaAgarrado=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)>0.7f && tocandoLpalanca==true) {
            lPalanca.transform.SetParent( transform ); 
           // rPalanca.GetComponent<Rigidbody>().useGravity=false; 
            LpalancaAgarrado=true;
             lPalancaRender.material= materialverde;
            //rPalanca.transform.position=new Vector3(transform.position.x+0.0051f,transform.position.y, transform.position.z);
            lPalanca.transform.position=new Vector3(transform.position.x,transform.position.y, transform.position.z);
            lPalanca.transform.localPosition=Vector3.zero;
            lPalanca.transform.localRotation= Quaternion.identity;
            lPalanca.GetComponent<Rigidbody>().isKinematic=true;
        }
       if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)<0.7f) {
            //lPalanca.transform.parent=null; 
            if (LpalancaAgarrado)
            {
             lPalancaRender.material= materialrojo;
            }
        }
    }
      private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Lpalanca")
        {
             Debug.Log(other.name);
             tocandoLpalanca=true;
        }
    }
}
