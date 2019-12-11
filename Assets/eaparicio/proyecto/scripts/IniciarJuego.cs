using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJuego : MonoBehaviour
{
    bool iniciar;
    public Renderer rend;
    public Material apagado;
    public Material encendido;
    void Start()
    {
        iniciar=false;
        rend.material = apagado;
    }
    void Update()
    {
        if (iniciar)
        {
            this.MoverBoton();
        }
    }
    void MoverBoton(){
        Vector3 boton_pulsado = new Vector3(-0.351f, 0.989f, 0.055f);
        transform.position = Vector3.Lerp(transform.position, boton_pulsado, 0.08f);
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag=="mano")
        {
            iniciar=true;   
            rend.material = encendido;         
        }
    }
}
