using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrab : MonoBehaviour
{
    [SerializeField]
    protected OVRInput.Controller m_controller;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag=="Grab" && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller)==1)
        {
            other.transform.parent=transform;
        }
    }
}
