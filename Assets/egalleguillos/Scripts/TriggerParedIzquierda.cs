using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParedIzquierda : MonoBehaviour
{
   int r;
    private void Update() {
        r = Random.Range(1,4);
    }
    
    void OnTriggerEnter(Collider c) {
        if(c.tag == "DianaIzquierda"){

            if (GetComponent<Collider>().tag == "ColliderIzqIzq")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,-90,45);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,-90,140);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,-90,90);
                        break;
                }
            }
            
            if (GetComponent<Collider>().tag == "ColliderInfIzq")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,-90,-45);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,-90,45);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,-90,0);
                        break;
                }
            }
            if (GetComponent<Collider>().tag == "ColliderSupIzq")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,-90,130);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,-90,220);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,-90,180);
                        break;
                }
            }

            if (GetComponent<Collider>().tag == "ColliderDerIzq")
            {
                switch (r)
                {
                    case 1:
                        c.transform.localRotation = Quaternion.Euler(0,-90,-45);
                        break;
                    case 2:
                        c.transform.localRotation = Quaternion.Euler(0,-90,-90);
                        break;
                    case 3:
                        c.transform.localRotation = Quaternion.Euler(0,-90,-130);
                        break;
                }
            }
        }
    }
}

