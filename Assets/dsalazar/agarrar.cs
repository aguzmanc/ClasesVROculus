using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // arco.transform.SetParent( transform );
       //  Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
       if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)<0.7f) {
            arco.transform.parent=null;
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            arco.transform.parent=null;
        }
    }
    public GameObject arco;
    private void OnTriggerEnter(Collider other) {
        //if (other.gameObject.tag=="arco")
        //{
           // other = GetOtherGameObject();
            arco.transform.SetParent( transform );
             Debug.Log("toco");
          //  other.transform.SetParent( transform, worldPositionStays );
        //}
    }
}
