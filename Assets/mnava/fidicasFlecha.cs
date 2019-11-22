using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fidicasFlecha : MonoBehaviour
{
    bool disparada;
    // Start is called before the first frame update
    void Start()
    {
        disparada=false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(disparada)
        {
            transform.Translate(0,0,0.5f,Space.Self);
        }
    }
    public void cambiarK()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
        rb.isKinematic=false;
        transform.parent=null;
        disparada=true;
    }
    public void volverK()
    {
        Rigidbody rb=transform.GetComponent<Rigidbody>();
        rb.isKinematic=true;
        disparada=false;
    }
    public void tp()
    {
         transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
    }
}
