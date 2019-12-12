using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBolaBlanca : MonoBehaviour
{

    Rigidbody rb ;
    public bool prueba;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.LTouch))
           
        {
               prueba = true;
        }
        */
        if (prueba)
           
        {
                rb.isKinematic = true;
                transform.localPosition = new Vector3(1.163f,1.199755f,1.219f);
                 transform.localRotation = Quaternion.Euler(0,0,0);
                 rb.isKinematic = false;
                 prueba=false;
        }
    }
}
