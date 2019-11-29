using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour {
    public GameObject cannonPivotBone;
    public GameObject bullet;
    public float shootCooldown = 1;
    public float strength = 20;

    public float velocidadInclinacion = 180; //antes era 180
    public float velocidadDireccion = 270; //antes era 360

    float _timeSinceLastShot = 0;
   
    public GameObject manoDerecha;
    public bool cuerdaAgarrado=false;


    AreaShoot verifArea= new AreaShoot();

    void Update () {
        
        
        float distancia=Vector3.Distance( cannonPivotBone.transform.position,manoDerecha.transform.position);

          //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
          if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)>0.7f) //sera esto para derecha?
         {
              Debug.DrawRay(cannonPivotBone.transform.position, transform.TransformDirection(manoDerecha.transform.position) , Color.white);
         }
          //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)>0.7f&&manoArea1==true) { //sera esto para derecha?
          if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)) { //sera esto para derecha?
                      GameObject createdBullet = Instantiate(bullet);
              Debug.DrawRay(cannonPivotBone.transform.position, transform.TransformDirection(manoDerecha.transform.position) , Color.white);
              createdBullet.transform.position = cannonPivotBone.transform.position;
              
             // createdBullet.transform.SetParent( transform ); //agarra si esta en el area y se ejerce en el handtriger
              strength=(50*distancia);   
               Rigidbody body = createdBullet.GetComponent<Rigidbody>();
        body.AddForce(cannonPivotBone.transform.forward * strength, ForceMode.Impulse);
            //Shoot();
        }
     if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
     
    }
    
    public void Shoot () {
        GameObject createdBullet = Instantiate(bullet);
        createdBullet.transform.position = cannonPivotBone.transform.position;
       //       createdBullet.transform.SetParent( transform ); //agarra si esta en el area y se ejerce en el handtriger

        Rigidbody body = createdBullet.GetComponent<Rigidbody>();
       // createdBullet.transform.rotation = cannonPivotBone.transform.rotation;

        body.AddForce(cannonPivotBone.transform.forward * strength,
                      ForceMode.Impulse);
    }

    public void UpdatePlayerControl () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }

      //  transform.Rotate(0, velocidadDireccion * Time.deltaTime * Input.GetAxis("Horizontal"), 0);
        //cannonPivotBone.transform.Rotate(velocidadInclinacion * Time.deltaTime * Input.GetAxis("Vertical") * -1 ,0,0);
    }
}
