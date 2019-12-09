using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMuerte : MonoBehaviour
{
    public float timer = 0;
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if((int)timer == 5){
            rigidbody.useGravity = true;
        }
    }

    void OnTriggerEnter(Collider c) {
        if(c.tag == "Player"){
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
