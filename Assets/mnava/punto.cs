using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punto : MonoBehaviour
{
    public Transform derecha;
     public Transform izquierda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x,y,z;
        x=(derecha.position.x+izquierda.position.x)/2;
         y=(derecha.position.y+izquierda.position.y)/2;
          z=(derecha.position.z+izquierda.position.z)/2;
          transform.position=new Vector3(x,y,z);
        
    }
}
