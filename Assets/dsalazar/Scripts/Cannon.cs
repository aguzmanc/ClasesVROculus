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
    public bool manoArea1=false;
    public bool manoArea2=false;
    public bool manoArea3=false;

    AreaShoot verifArea= new AreaShoot();

    void Update () {
        manoArea1=verifArea.manoArea1;
        manoArea2=verifArea.manoArea2;
        manoArea3=verifArea.manoArea3;
          //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
          if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)>0.7f&&manoArea1==true) { //sera esto para derecha?

            //  if (manoArea1)
              //{
              //    strength=20;
              //}
               //if (manoArea2)
              //{
                //  strength=40;
              //}
               //if (manoArea3)
              //{
                //  strength=60;
              //}
              strength=10+(50*verifArea.distancia);   
            Shoot();
        }
     if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    public void Shoot () {
        GameObject createdBullet = Instantiate(bullet);
        createdBullet.transform.position = cannonPivotBone.transform.position;
        Rigidbody body = createdBullet.GetComponent<Rigidbody>();
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
