using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorBallestaW : MonoBehaviour
{
         //Ballesta 
      public BallestaW ballesta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ballesta"){
            BallestaW balle = other.GetComponent<BallestaW>();
            ballesta = balle;
            ballesta.Tocar();
        }
    }
}
