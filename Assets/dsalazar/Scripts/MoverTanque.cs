using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTanque : MonoBehaviour
{
   public float distanciaR;
   public float distanciaL;


   public GameObject rPalanca;
   public GameObject lPalanca;
   public GameObject Rcentro;
   public GameObject Lcentro;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          distanciaR = Vector3.Distance(rPalanca.transform.position, Rcentro.transform.position);
          distanciaL = Vector3.Distance(lPalanca.transform.position, Lcentro.transform.position);
        if (distanciaL>0.315F&&distanciaR>0.315f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else if(distanciaL>0.315f&&distanciaR<0.315f)
        {
            transform.Rotate(0.0f,0.7f*Time.deltaTime, 0.0f, Space.World);
        }
          else if(distanciaL<0.315f&&distanciaR>0.315f)
        {
            transform.Rotate(0.0f,-0.7f, 0.01f*Time.deltaTime, Space.World);
        }
        // Vector3 thePosition = transform.TransformPoint(2, 0, 0);
      //  Instantiate(someObject, thePosition, someObject.transform.rotation);


    }
}
