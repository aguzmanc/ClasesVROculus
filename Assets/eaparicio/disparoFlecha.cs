using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoFlecha : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Disparar(float distancia){
        Debug.Log("Disparo");
        Debug.Log(distancia);
        transform.position = new Vector3(0,0,distancia);
        distancia-=0.001f;
    }
}
