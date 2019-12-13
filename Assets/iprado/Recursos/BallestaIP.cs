using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaIP : MonoBehaviour
{
    public Material noStatus;
    public Material taken;
    public Material canTake;

    public Renderer rend;
    Rigidbody body;

  
    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }
    public void Tocar() {
        rend.material = canTake;
    }


    public void DejarDeTocar() {
        rend.material = noStatus;
    }

    public void Agarrar(Transform takeTool) { 
        rend.material = taken;
        body.isKinematic = true;
        transform.parent = takeTool;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        
    }
    public void Soltar() {
        transform.parent = null;
        rend.material = canTake;
        body.isKinematic = false;
    }
}
