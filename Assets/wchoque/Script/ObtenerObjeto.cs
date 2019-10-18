using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerObjeto : MonoBehaviour
{
    public Vector3 distancia;
    public GameObject obj2;
    GameObject centro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia =Vector3.Lerp(transform.position,obj2.transform.position,0.5f);
        if (centro!=null)
        {
        centro.transform.position = distancia;    
        }
        
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.name == "ObjetoAAlzar")
        {
            other.gameObject.transform.parent = transform;
            centro = other.gameObject;
        }
    }


}
