using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoFlecha : MonoBehaviour
{
    public GameObject flechaPrefab;
    public GameObject flecha;
    float distancia=0;
    float rotacion=0;
    bool disparar;
    void Start()
    {
        disparar=false;
        transform.GetComponent<Rigidbody>().useGravity=false;
    }

    void Update()
    {
        
        if (disparar)
        {
            transform.GetComponent<Rigidbody>().useGravity=true;
            transform.Translate(new Vector3(0,0,-distancia*Time.deltaTime*70), Space.Self);
            distancia-=0.001f;
            transform.Rotate(new Vector3(rotacion/-distancia,0,0), Space.Self);
        }
    }

    public void Disparar(float distan){
        gameObject.layer = LayerMask.NameToLayer("flecha");
        Debug.Log(1<<9);
        Debug.Log(1<<5);
        Debug.Log(gameObject.layer);
        
        distancia = distan;
        rotacion=distancia*2.5f;
        disparar=true;
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="pared")
        {
            disparar=false;
            transform.GetComponent<Rigidbody>().isKinematic=true;
            flecha = Instantiate(flechaPrefab);
            flecha.transform.parent=GameObject.Find("cuerda").transform;
            flecha.transform.localPosition=Vector3.zero;
            flecha.transform.localRotation=Quaternion.identity;
            
        }
        
    }
}
