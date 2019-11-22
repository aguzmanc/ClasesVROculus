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

    void Update () {
          if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)>0.9f) {
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
        // al importar modelos de blender, las rotaciones se importan
        // de una forma muy caótica... el eje y del hueso que indica
        // la orientación del cañón, está apuntando hacia donde la
        // bala debería ir.
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
