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
        float triggerValD=OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        float triggerValI=OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        if (triggerValD>0.7f)
        {
            Instantiate(bala,mano1.transform.position,mano1.transform.rotation);
        }
          if (triggerValI>0.7f)
        {
            Instantiate(bala,mano2.transform.position,mano2.transform.rotation);
        }
    }
}
