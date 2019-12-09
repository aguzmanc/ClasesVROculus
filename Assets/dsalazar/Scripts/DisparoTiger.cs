using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTiger : MonoBehaviour
{
     public GameObject cannonPivotBone;
    public GameObject bullet;
    public float shootCooldown = 1;
    public float strength = 50;
    public bool cargado=true;
    void Start()
    {
        
    }
    void Update()
    {
           if (Input.GetKeyDown(KeyCode.Space)&&cargado) {
            Shoot();
            cargado=false;
        } 
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&cargado) {
            Shoot();
            //Debug.Break();
            cargado=false;
        }
         if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
           // Shoot();
            cargado=true;
           // Debug.Break();

        }

    }
       public void Shoot () {
        GameObject createdBullet = Instantiate(bullet);
        createdBullet.transform.position = cannonPivotBone.transform.position;
        Rigidbody body = createdBullet.GetComponent<Rigidbody>();
        body.AddForce(cannonPivotBone.transform.forward * strength,
                      ForceMode.Impulse);
    }
}
