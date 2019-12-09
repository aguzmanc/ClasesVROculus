using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParedDerecha : MonoBehaviour
{
    int r;
    private void Update() {
        r = Random.Range(1,4);
    }
    

    void OnTriggerEnter(Collider c) {
        if(c.tag == "DianaDerecha"){

            if (GetComponent<Collider>().tag == "ColliderIzqDer")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,90,300);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,90,400);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,90,360);
                        break;
                }
            }
            
            if (GetComponent<Collider>().tag == "ColliderInfDer")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,90,220);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,90,270);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,90,300);
                        break;
                }
            }
            if (GetComponent<Collider>().tag == "ColliderSupDer")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,90,130);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,90,45);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,90,90);
                        break;
                }
            }

            if (GetComponent<Collider>().tag == "ColliderDerDer")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,90,120);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,90,180);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,90,220);
                        break;
                }
            }
        }
    }
}

