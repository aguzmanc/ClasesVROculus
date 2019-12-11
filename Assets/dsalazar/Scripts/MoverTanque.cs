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
    public GameObject tanque;
    public GameObject torreta;


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
          if (Input.GetKey(KeyCode.W)) {
            tanque.transform.Translate(Vector3.forward * Time.deltaTime*4);
        }
        if (Input.GetKey(KeyCode.D)) {
            tanque.transform.Rotate(0.0f,30f*Time.deltaTime, 0.0f, Space.World);
        }
        if (Input.GetKey(KeyCode.S)) {
            tanque.transform.Translate(-Vector3.forward * Time.deltaTime*2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tanque.transform.Rotate(0.0f,-30f*Time.deltaTime, 0.0f, Space.World);
        }

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)== (new Vector2(1, 0))) {
            torreta.transform.Rotate(0.0f,30f*Time.deltaTime, 0.0f, Space.World);
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)== (new Vector2(-1, 0))) {
            torreta.transform.Rotate(0.0f,-30f*Time.deltaTime, 0.0f, Space.World);
        }
        if (distanciaL>0.05f&&distanciaR>0.05f)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime);
            if (ladelante&&radelante)
            {
            tanque.transform.Translate(Vector3.forward * Time.deltaTime*4);
            }
            if (latras&&ratras)
            {
            tanque.transform.Translate(-Vector3.forward * Time.deltaTime*2);
            }
            if (ladelante&&ratras)
            {
            tanque.transform.Rotate(0.0f,30f*Time.deltaTime, 0.0f, Space.World);
            }
            if (latras&&radelante)
            {
            tanque.transform.Rotate(0.0f,-30f*Time.deltaTime, 0.0f, Space.World);
            }
        }
        else if(distanciaL>0.05f&&distanciaR<0.05f)
        {
            if (ladelante)
            {
            tanque.transform.Translate(Vector3.forward * Time.deltaTime);
            tanque.transform.Rotate(0.0f,20f*Time.deltaTime, 0.0f, Space.World);
            }
            if (latras)
            {
            tanque.transform.Rotate(0.0f,-20f*Time.deltaTime, 0.0f, Space.World);
                
            }
        }
          else if(distanciaL<0.05f&&distanciaR>0.05f)
        {
            if (radelante)
            {
            tanque.transform.Rotate(0.0f,-20f*Time.deltaTime, 0, Space.World);
            tanque.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            if (ratras)
            {
            tanque.transform.Rotate(0.0f, 20f*Time.deltaTime,0, Space.World);
                
            }
        }
      


    }
}
