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
      if (tocoarco)
      {
       arco.transform.position= transform.position;
          
      }
    }
    public GameObject arco;
    bool tocoarco=false;
    private void OnTriggerEnter(Collider other) {
        //if (other.gameObject.tag=="arco")
        //{
           // other = GetOtherGameObject();
            arco.transform.SetParent( transform );
             Debug.Log("toco");
             tocoarco=true;
          //  other.transform.SetParent( transform, worldPositionStays );
        //}
    }
}
