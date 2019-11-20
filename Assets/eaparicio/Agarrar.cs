using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrar : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider otro) {
        Debug.Log(otro.name);
        arco arc = otro.GetComponent<arco>();
        Debug.Log(arc);
        if (arc!=null)
        {
            arc.Tocar();
        }
    }

    void OnTriggerExit(Collider otro)
    {
        Debug.Log(otro.name);
        arco arc = otro.GetComponent<arco>();
        if (arc!=null)
        {
            arc.DejarTocar();
        }
    }
}
