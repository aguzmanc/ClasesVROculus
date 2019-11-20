using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    public float distancia=1.7f;
    float rotacion=5;
    bool disparo=false;
    void Start()
    {
        transform.GetComponent<Rigidbody>().useGravity=false;
    }

    void Update()
    {

        //if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)==1)
        if (Input.GetKeyDown(KeyCode.A))
        {
            Transform punto_distancia = GameObject.Find("punto_distancia").GetComponent<Transform>();
            distancia=(transform.position.magnitude-punto_distancia.position.magnitude)*20;
            disparo=true;
            transform.GetComponent<Rigidbody>().useGravity=true;
            Debug.Log("Disparo");
        }
        if (distancia>0 && disparo)
        {
            transform.Translate(new Vector3(0,0,distancia*Time.deltaTime), Space.Self);
            distancia-=0.01f;
            transform.Rotate(new Vector3(rotacion/distancia,0,0), Space.Self);
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        disparo=false;
    }
}
