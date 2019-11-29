using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorIzq : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnTriggerEnter(Collider c) {
        if(c.tag == "Ballesta"){

        }

    }

    void OnTriggerExit(Collider c) {
        if(c.tag == "Ballesta"){
            
        }
    }
}
