using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
    // Start is called before the first frame update
     Rigidbody rig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rig=GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag=="pared")
        {
            rig.constraints=RigidbodyConstraints.FreezeAll;
            rig.isKinematic=true;
        }
        //other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
       // other.attachedRigidbody.isKinematic=true;
        //other.attachedRigidbody.constraints=RigidbodyConstraints.FreezeAll;
        
    }
}
