using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevolverLanza : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnTriggerEnter(Collider other) {
        if(other.tag=="Arma3")
        {
            other.transform.position=new Vector3(-0.05671f,0.957f,0.31f);
            other. transform.localRotation =  Quaternion.Euler(90, 0, 0);
             Rigidbody lanzaCuerpo=other.GetComponent<Rigidbody>();
             lanzaCuerpo.isKinematic=true;
        }
      }
}
