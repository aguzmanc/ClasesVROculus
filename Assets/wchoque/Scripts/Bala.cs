using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody rigidbody;
    public bool disparo;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        disparo=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(disparo!=false){
        if ( Physics.Raycast (transform.position, transform.forward, 10)){
        Debug.DrawRay (transform.position, transform.forward * 10, Color.yellow );
            Debug.Log ("Did Hit");
        }
            
        transform.position += transform.forward * 25 * Time.deltaTime;
        }
    }

    public void dispararBala(){
        transform.parent = null;
        rigidbody.isKinematic = true;
        disparo=true;
    }
}
