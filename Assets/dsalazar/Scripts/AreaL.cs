using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaL : MonoBehaviour
{
   public bool ladelante=false;
    public bool latras=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name=="LAdelante")
        {
            ladelante=true;
            latras=false;
        }
        if (other.gameObject.name=="LAtras")
        {
            latras=true;
            ladelante=false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="LAdelante")
        {
            ladelante=false;
        }
        if (other.gameObject.name=="LAtras")
        {
            latras=false;
        }
    }
}
