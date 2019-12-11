using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaL : MonoBehaviour
{
   public bool ladelante=false;
    public bool latras=false;
     public Renderer lAreaAdelante;
     public Renderer lAreaAtras;

    public Material materialAmarilloAlert;
    public Material materialAmarilloTransparente;

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
            lAreaAdelante.material=materialAmarilloAlert;
        }
        
        if (other.gameObject.name=="LAtras")
        {
            latras=true;
            ladelante=false;
            lAreaAtras.material=materialAmarilloAlert;
        }

    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="LAdelante")
        {
            ladelante=false;
            lAreaAdelante.material=materialAmarilloTransparente;
        }
        if (other.gameObject.name=="LAtras")
        {
            latras=false;
            lAreaAtras.material=materialAmarilloTransparente;

        }
    }
}
