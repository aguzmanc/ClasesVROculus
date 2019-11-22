using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradoraCuerda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Cuerda")
        {
           //Cuerda cuerda=  other.GetComponent<Cuerda>();
           // cuerda.Tocar();
           
        }

    }

    private void OnTriggerExit(Collider other) {
        
    }
}
