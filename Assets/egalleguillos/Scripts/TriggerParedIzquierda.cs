using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParedIzquierda : MonoBehaviour
{
    int r;
    private void Update() {
        r = Random.Range(1,5);
    }
    
    void OnTriggerEnter(Collider c) {
        if(c.tag == "DianaIzquierda"){
            switch(r){
                case 1:
                    c.transform.Rotate(new Vector3(0, 0, -45));
                    break;
                case 2:
                    c.transform.Rotate(new Vector3(0, 0, 45));
                    break;
                case 3:
                    c.transform.Rotate(new Vector3(0, 0, 90));
                    break;
                case 4:
                    c.transform.Rotate(new Vector3(0, 0, -90));
                    break;
            }
        }
    }
}
