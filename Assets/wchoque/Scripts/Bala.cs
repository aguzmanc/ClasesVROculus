using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody rigidbody;
    public bool disparo;
    public bool noColliderChoca;
    public bool ganoPuntos;
    float tiempoActivo;
    public bool choco;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        disparo=false;
        noColliderChoca = false;
        ganoPuntos = false;
        choco = false;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += transform.forward * 25 * Time.deltaTime;
        if(disparo!=false){
             RaycastHit hit;
        if ( Physics.Raycast (transform.position, transform.forward, out hit,5)){
            if(hit.collider !=null){
               // if(hit.collider.gameObject.name == "azul"){
                    noColliderChoca=true;
                    transform.position = hit.point;
                    choco =true;
                    // 
            }
            Debug.DrawRay (transform.position, transform.forward * hit.distance, Color.yellow );
          //  Debug.Log ("Did Hit");
        }
          /*  if(noColliderChoca!=true){
                transform.position += transform.forward * 25 * Time.deltaTime;
            }*/
            
        }
        if(choco){
            tiempoActivo+=Time.deltaTime;
            if(tiempoActivo >=6){
               Destroy(transform.gameObject);
               
            }
        }
    }

    public void dispararBala(){
        transform.parent = null;
        rigidbody.isKinematic = false;
      //  disparo=true;
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Destroy(transform.gameObject);
    }
}
