using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // arco.transform.SetParent( transform );
       //  Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
      //OVRInput.RawAxis1D.RHandTrigger
      if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)>0.7f && tocando==true) {
            arco.transform.SetParent( transform );
        }
       if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)<0.7f) {
            arco.transform.parent=null;
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            arco.transform.parent=null;
        }
    }
    public GameObject arco;
    bool tocando;
    private void OnTriggerEnter(Collider other) {
        //if (other.gameObject.tag=="arco")
        //{
           // other = GetOtherGameObject();
           // arco.transform.SetParent( transform );
             Debug.Log("toco");
             tocando=true;
          //  other.transform.SetParent( transform, worldPositionStays );
        //}
    }
    private void OnTriggerStay(Collider other) {
             tocando=true;
    }
    private void OnTriggerExit(Collider other) {
      tocando=false;
    }
}
