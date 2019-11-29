using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarradorCulataBallesta : MonoBehaviour
{
    AgarradorCuerdaBallesta agarradorCuerdaBallesta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(agarradorCuerdaBallesta!=null){
            if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger,OVRInput.Controller.RTouch) && agarradorCuerdaBallesta.prepararMunicion==true){
                agarradorCuerdaBallesta.lanzarFlecha();
            }
        }
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.name =="AgarreDisparo"){
            Debug.Log("entro al arco de la culata");
            agarradorCuerdaBallesta = transform.GetComponent<AgarradorCuerdaBallesta>();
        }        
    }
}
