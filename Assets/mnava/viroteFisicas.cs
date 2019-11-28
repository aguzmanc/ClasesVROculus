using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viroteFisicas : MonoBehaviour
{
    public bool disparada;
     Rigidbody cuerpo;
    // Start is called before the first frame update
    void Start()
    {
        disparada=false;
        cuerpo= this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(disparada)
        {
            //transform.Translate(0,0,1*Time.deltaTime,Space.Self);
           
            cuerpo.AddForce(transform.forward*5);
           
        }
    }

    public void tp(Transform origen)
    {    
        disparada=false;
        cuerpo.isKinematic=false;
        transform.parent=origen;
        transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.Euler(0,-180,0);

    }
    public void flechaLanzada()
    {
         
          cuerpo.isKinematic=false;
          transform.parent=null;
          disparada=true;
    }
     void OnTriggerEnter(Collider other) {
       if(other.tag=="pared")
       {
         
            cuerpo.isKinematic=true;
            disparada=false;
           Debug.Log("Si");
       }
        
    }
}
