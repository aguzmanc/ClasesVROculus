using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaR : MonoBehaviour
{
 public bool radelante=false;
    public bool ratras=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name=="RAdelante")
        {
            radelante=true;
            ratras=false;
        }
        if (other.gameObject.name=="RAtras")
        {
            ratras=true;
            radelante=false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="RAdelante")
        {
            radelante=false;
        }
        if (other.gameObject.name=="RAtras")
        {
            ratras=false;
        }
    }
}
