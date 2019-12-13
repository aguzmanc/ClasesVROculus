using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorIP : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Agarrar(Transform manoIzquierda) { 
        // rend.material = taken;
        body.isKinematic = true;
        body.useGravity=false;
        transform.parent = manoIzquierda;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        
    }

    public void Soltar() {
        transform.parent = null;
        // rend.material = canTake;
        body.isKinematic = false;
        body.useGravity = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ChargerSlot"))
        {
            Destroy(this.gameObject);
        }
    }
}
