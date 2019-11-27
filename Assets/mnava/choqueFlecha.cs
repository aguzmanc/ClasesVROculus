using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choqueFlecha : MonoBehaviour
{
     public Transform flechaPadre;
      fidicasFlecha feleCuer;
    // Start is called before the first frame update
    void Start()
    {
       feleCuer=flechaPadre.GetComponent<fidicasFlecha>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) {
       if(other.tag=="pared")
       {
           feleCuer.parar();
           Debug.Log("Si");
       }
        
    }
}
