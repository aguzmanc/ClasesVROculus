using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaGolpe : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bola")
        {
            print("entro");
            rb.AddForce(this.transform.parent.forward * 4,ForceMode.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
