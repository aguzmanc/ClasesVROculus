using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDianaDerecha : MonoBehaviour
{
    GameObject dianaRojaDer;
    GameObject dianaVerdeDer;
    GameObject dianaAmarillaDer;
    void Start()
    {
        dianaAmarillaDer = transform.GetChild(0).gameObject;
        dianaRojaDer = transform.GetChild(1).gameObject;
        dianaVerdeDer = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        
    }
}
