using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrar : MonoBehaviour
{
    public Transform mano1;
    public Transform mano2;

    bool agarrado;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(agarrado)
            transform.position=(mano1.position+mano2.position)/2;
    }


    private void OnTriggerEnter(Collider other) {

        
       agarrado=other.tag=="Mano";
    }
}
