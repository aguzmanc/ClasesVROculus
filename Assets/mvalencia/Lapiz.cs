using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapiz : MonoBehaviour
{
    // Start is called before the first frame update
      Rigidbody body;
  
    void Start()
    {
         body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Agarrar(Transform agarrador)
    {   
        
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
       
    }


    public void Soltar()
    {
        transform.parent = null;
        
        body.isKinematic = false;

       
    }
}
