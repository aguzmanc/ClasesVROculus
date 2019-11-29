using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaFire : MonoBehaviour
{
      public GameObject cannonPivotBone;
    public GameObject bullet;
    public float shootCooldown = 1;
    public float strength = 0;

    public float velocidadInclinacion = 180; //antes era 180
    public float velocidadDireccion = 270; //antes era 360

    float _timeSinceLastShot = 0;

    public GameObject manoDerecha;
    public GameObject manoIzquierda;
    void Start()
    {
        
    }
    void Update()
    {
         if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)>0.7f||Input.GetKeyDown(KeyCode.Space))
         {
        GameObject createdBullet = Instantiate(bullet);
              createdBullet.transform.position = cannonPivotBone.transform.position;
              strength=(50);   
               Rigidbody body = createdBullet.GetComponent<Rigidbody>();
        body.AddForce(cannonPivotBone.transform.forward * strength, ForceMode.Impulse);
         }
    }
}
