using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class proy_base : MonoBehaviour
{
    // Start is called before the first frame update
    
    Proy_controlador controlador;
    void Start()
    {
        Debug.Log(this.gameObject.tag);
        controlador = Proy_controlador.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider otro) 
    {
        if (otro.gameObject.tag != "Untagged")
        {
            if(otro.gameObject.tag == this.gameObject.tag) 
            {
                Debug.Log("Correcto");
                controlador.ActualizarPuntaje(1);
            }
            else
            {
                Debug.Log("Equivocado");
                controlador.ActualizarPuntaje(-3);
            }
        }

        Destroy (otro.gameObject);
    }
}
