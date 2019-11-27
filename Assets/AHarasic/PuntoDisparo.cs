using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDisparo : MonoBehaviour
{
    public GameObject arco;
    // Start is called before the first frame update
    public GameObject prfabFlecha;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            DisparaFlecha(100);
        }
        Test();
        // float actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        
    }

    public void DisparaFlecha(float speed)
    {
        //Quaternion quaternion = Quaternion.Euler(90, 0, 0);
        Quaternion quaternion = Quaternion.Euler(0, 0, 0);
        GameObject f = Instantiate(prfabFlecha,transform.position,quaternion);
        f.GetComponent<Rigidbody>().AddForce(arco.transform.forward*speed*2);
        Destroy(f,10);
    }


    private void Test()
    {
         if(OVRInput.GetDown(OVRInput.Button.One))
        {
             DisparaFlecha(102);
        }
    }
}
