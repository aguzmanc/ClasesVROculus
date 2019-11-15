using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoltarAgarrar : MonoBehaviour
{
    // Start is called before the first frame update
      public Transform mano1;
    public Transform objetoagarrado;

   // bool agarrado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)>0.7f) {
            objetoagarrado.transform.parent=mano1.transform;
        }
       if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)<0.7f) {
           objetoagarrado.transform.parent=null;
            objetoagarrado.transform.position=new Vector3(1,1,1);

        }
        
        if (Input.GetKeyDown(KeyCode.Z)) {
            objetoagarrado.transform.parent=mano1.transform;
        }
         if (Input.GetKeyDown(KeyCode.A)) {
           objetoagarrado.transform.parent=null;
            objetoagarrado.transform.position=new Vector3(1,1,1);
        }
        
        //  if(agarrado)
           // transform.position=(mano1.position+mano2.position)/2;
    }
      // private void OnTriggerEnter(Collider other) {

          
       //agarrado=other.tag=="Mano";
    //}
}
