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
     AreaL areaL ;
    AreaR areaR ;
    public bool ladelante=false;
    public bool latras=false;
    public bool radelante=false;
    public bool ratras=false;

    void Start()
    {
        areaL =  lPalanca.GetComponent<AreaL>();
     areaR = rPalanca.GetComponent<AreaR>();
    }


    void Update()
    {
     
        ladelante=areaL.ladelante;
        latras=areaL.latras;
        radelante=areaR.radelante;
        ratras=areaR.ratras;

          distanciaR = Vector3.Distance(rPalanca.transform.position, Rcentro.transform.position);
          distanciaL = Vector3.Distance(lPalanca.transform.position, Lcentro.transform.position);
        if (distanciaL>0.05f&&distanciaR>0.05f)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime);
            if (ladelante&&radelante)
            {
            transform.Translate(Vector3.forward * Time.deltaTime*2);
            }
            if (latras&&ratras)
            {
            transform.Translate(-Vector3.forward * Time.deltaTime*2);
            }
            if (ladelante&&ratras)
            {
            transform.Rotate(0.0f,30f*Time.deltaTime, 0.0f, Space.World);
            }
            if (latras&&radelante)
            {
            transform.Rotate(0.0f,-30f*Time.deltaTime, 0.0f, Space.World);
            }
        }
        else if(distanciaL>0.05f&&distanciaR<0.05f)
        {
            if (ladelante)
            {
            transform.Translate(Vector3.forward * Time.deltaTime);
            transform.Rotate(0.0f,20f*Time.deltaTime, 0.0f, Space.World);
            }
            if (latras)
            {
            transform.Rotate(0.0f,-20f*Time.deltaTime, 0.0f, Space.World);
                
            }
        }
          else if(distanciaL<0.05f&&distanciaR>0.05f)
        {
            if (radelante)
            {
            transform.Rotate(0.0f,-20f*Time.deltaTime, 0, Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime);
            }
            if (ratras)
            {
            transform.Rotate(0.0f, 20f*Time.deltaTime,0, Space.World);
                
            }
        }
      


    }
}
