using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianaCentro : MonoBehaviour
{
    GameObject dianaRojaCen;
    GameObject dianaVerdeCen;
    GameObject dianaAmarillaCen;

    ControladorCentro controlador;
    void Start()
    {
        dianaAmarillaCen = transform.GetChild(0).gameObject;
        dianaRojaCen = transform.GetChild(1).gameObject;
        dianaVerdeCen = transform.GetChild(2).gameObject;
        controlador = FindObjectOfType<ControladorCentro>();
    }

    void Update()
    {
        switch(controlador.activo){
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
