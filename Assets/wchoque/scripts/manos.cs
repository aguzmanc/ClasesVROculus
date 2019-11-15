using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manos : MonoBehaviour
{
    public Rigidbody arco;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if(other.name=="mano"){
            if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger)==1)
            {
                gameObject.transform.parent = other.gameObject.transform;
                gameObject.transform.position = Vector3.zero;
            }
            if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger)==0)
            {
                gameObject.transform.parent=null;
                arco.isKinematic=false;
            }
        }
    }
}
