using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerChoque : MonoBehaviour
{   public int count=0;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
         txt.text="Puntaje: ";
    }

    // Update is called once per frame
    void Update()
    {
           if(OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Three)  || Input.GetKeyDown(KeyCode.P))
      {
         // Debug.Log("2siuu");
        count=0;
      }
      
    }


       private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag=="pelota")
        {
            count++;
            Debug.Log(count);
            txt.text="Puntaje: "+count.ToString();
        }
        //other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
       // other.attachedRigidbody.isKinematic=true;
        //other.attachedRigidbody.constraints=RigidbodyConstraints.FreezeAll;
        
    }
}