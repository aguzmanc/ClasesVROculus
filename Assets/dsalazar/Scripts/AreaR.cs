using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaR : MonoBehaviour
{
 public bool radelante=false;
    public bool ratras=false;
    public Renderer rAreaAdelante;
     public Renderer rAreaAtras;

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
        if (other.gameObject.name=="RAdelante")
        {
            radelante=true;
            ratras=false;
            rAreaAdelante.material=materialAmarilloAlert;

        }
        if (other.gameObject.name=="RAtras")
        {
            ratras=true;
            radelante=false;
            rAreaAtras.material=materialAmarilloAlert;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="RAdelante")
        {
            radelante=false;
            rAreaAdelante.material=materialAmarilloTransparente;
        }
        if (other.gameObject.name=="RAtras")
        {
            ratras=false;
            rAreaAtras.material=materialAmarilloTransparente;

        }
    }
}
