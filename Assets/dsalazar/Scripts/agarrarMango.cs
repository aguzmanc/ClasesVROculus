using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarMango : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public GameObject baseBallesta;
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)>0.7f||Input.GetKeyDown(KeyCode.B)) {
          //  baseBallesta.transform.position=transform.position;
            float distancia=Vector3.Distance( baseBallesta.transform.position,transform.position);
            transform.forward=-transform.forward;
            baseBallesta.transform.LookAt(transform);
        }
        else
        {
            
        }
        
    }
}
