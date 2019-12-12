using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoyos : MonoBehaviour
{

    public Rigidbody rbBola;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bola_Color")
        {
            Destroy(other.gameObject);
           
        }

        if (other.tag == "Bola")
        {
            
                rbBola.isKinematic=true;
                 other.transform.localPosition = new Vector3(1.163f,1.199755f,1.219f);
                 other.transform.localRotation = Quaternion.Euler(0,0,0);
                rbBola.isKinematic = false;
                
           
        }
    }
}
