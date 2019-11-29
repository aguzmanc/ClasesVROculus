using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    Rigidbody rb;
    float timed;
    bool disparado;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        timed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(disparado==true){
            timed+= Time.deltaTime;
            if(timed >5){
                Destroy(transform.parent.gameObject);
                timed=0;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("diana"))
        {
            rb.isKinematic = true;
            disparado = true;
        }
    }
}
