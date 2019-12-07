using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParedCentro : MonoBehaviour
{
    GameObject triggerSup;
    GameObject triggerInf;
    GameObject triggerDer;
    GameObject triggerIzq;
    int r;
    private void Update() {
        r = Random.Range(1,4);
    }
    
    void OnTriggerEnter(Collider c) {
        if(c.tag == "DianaCentro"){

            if (GetComponent<Collider>().tag == "ColliderIzquierdo")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,0,220);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,0,180);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,0,130);
                        break;
                }
            }
            
            if (GetComponent<Collider>().tag == "ColliderInferior")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,0,130);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,0,90);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,0,45);
                        break;
                }
            }
            if (GetComponent<Collider>().tag == "ColliderSuperior")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,0,220);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,0,270);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,0,300);
                        break;
                }
            }

            if (GetComponent<Collider>().tag == "ColliderDerecho")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,0,45);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,0,0);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,0,-45);
                        break;
                }
            }
        }
    }
}
