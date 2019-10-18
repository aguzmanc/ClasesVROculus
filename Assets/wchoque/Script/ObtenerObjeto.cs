using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtenerObjeto : MonoBehaviour
{
    public Vector3 distancia;
    public GameObject obj2;
    GameObject centro;
    public GameObject prefab;
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
        if(Input.GetKeyDown(KeyCode.Space)){
            Physics.Raycast(centro.transform.position, centro.transform.forward, 10);
              Debug.DrawRay(centro.transform.position, centro.transform.forward, Color.red);
            GameObject.Instantiate(prefab,new Vector3(centro.transform.position.x,centro.transform.position.y,centro.transform.position.z), Quaternion.identity);
            
            
        }    
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
