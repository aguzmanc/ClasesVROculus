using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTanque : MonoBehaviour
{
   public float distanciaR;
   public float distanciaL;


   public GameObject rPalanca;
   public GameObject lPalanca;
   public GameObject centro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          distanciaR = Vector3.Distance(rPalanca.transform.position, centro.transform.position);
          distanciaL = Vector3.Distance(lPalanca.transform.position, centro.transform.position);
        if (distanciaL>0.315F&&distanciaR>0.315f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else if(distanciaL>0.315f&&distanciaR<0.315f)
        {
            transform.Rotate(0.0f,1.0f*Time.deltaTime, 0.0f, Space.World);
        }
          else if(distanciaL<0.315f&&distanciaR>0.315f)
        {
            transform.Rotate(0.0f,-1.0f, 0.01f*Time.deltaTime, Space.World);
        }
    }
}
