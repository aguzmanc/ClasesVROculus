using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flechaW : MonoBehaviour
{
    Rigidbody rigidbody;
    float tiempo;
    bool lanzado;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        tiempo = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(lanzado==true){
            tiempo+= Time.deltaTime;
            if(tiempo >5){
                Destroy(transform.parent.gameObject);
                tiempo=0;
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="paredMadera"){
            rigidbody.isKinematic = true;
            lanzado = true;
        }
    }
}
