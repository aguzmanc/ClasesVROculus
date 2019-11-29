using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIzq : MonoBehaviour
{
    void OnTriggerEnter(Collider c) {
        if(c.tag == "Arco"){
            gameObject.GetComponent<AgarradoE>().enabled = true;
            gameObject.GetComponent<AgarradorIzq>().enabled = false;
        }
        if(c.tag == "Ballesta"){
            gameObject.GetComponent<AgarradorIzq>().enabled = true;
            gameObject.GetComponent<AgarradoE>().enabled = false;
        }
    }
}
