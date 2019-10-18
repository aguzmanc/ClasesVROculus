using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{

    public Transform mano1;
    public Transform mano2;

    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValD=OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);
        float triggerValI=OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch);
        if (triggerValD>0)
        {
            Instantiate(bala,mano1.transform.position,mano1.transform.rotation);
        }
          if (triggerValI>0)
        {
            Instantiate(bala,mano2.transform.position,mano2.transform.rotation);
        }
    }
}
