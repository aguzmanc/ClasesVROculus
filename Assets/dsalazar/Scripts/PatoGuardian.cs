using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatoGuardian : MonoBehaviour {
    public GameObject objetivo;

    void Update () {
        Vector3 origen = transform.position + transform.up * 1.5f;
        Vector3 direccion =
            (objetivo.transform.position - origen).normalized;
        RaycastHit hitInfo;
        if ( Physics.Raycast(origen, direccion, out  hitInfo ))
        {
           string nombre= hitInfo.collider.tag;
           if (nombre=="Player")
           {
                gameObject.GetComponent<Perseguidor>().enabled = true;
           }

        }

        Debug.DrawRay(origen, direccion * 100, Color.red);
    }
    
}
