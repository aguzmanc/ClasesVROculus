using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoFlecha : MonoBehaviour
{    
    Rigidbody rigidbody;
    public GameObject flechaPrefab;
    public GameObject flecha;
    public float distancia=0;
    public float rotacion=0;
    public bool disparar;
    void Start()
    {
        disparar=false;
        rigidbody= transform.GetComponent<Rigidbody>();
        rigidbody.useGravity=false;
    }

    void Update()
    {
        
        if (disparar)
        {
            rigidbody.useGravity=true;
            transform.Translate(new Vector3(0,0,-distancia*Time.deltaTime*70), Space.Self);
            //transform.Translate(0,0,distancia*Time.deltaTime);
            distancia-=0.001f;
            transform.Rotate(new Vector3(rotacion/-distancia,0,0), Space.Self);
            if (distancia<0)
            {
                disparar=false;
            }
        }
    }

    public void Disparar(float distan){
        // gameObject.layer = LayerMask.NameToLayer("flecha");
        // Debug.Log(gameObject.layer);
        distancia = distan;
        rotacion=distancia*2.5f;
        disparar=true;
        
    }
    private void OnTriggerEnter(Collider other) {
        //disparar=false;
        //rigidbody.useGravity=false;
        //Debug.Log(other.tag);
        if (other.tag=="pared" || other.tag=="piso" || other.tag=="diana")
        {
            disparar=false;
            rigidbody.isKinematic=true;
            flecha = Instantiate(flechaPrefab);
            flecha.transform.parent=GameObject.Find("cuerda").transform;
            flecha.transform.localPosition=Vector3.zero;
            flecha.transform.localRotation=Quaternion.identity;
            
        }
        
    }
}
