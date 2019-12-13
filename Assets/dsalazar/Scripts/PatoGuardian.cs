using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatoGuardian : MonoBehaviour {
    public GameObject objetivo;

        public GameObject cannonPivotBone;
    public GameObject bullet;
    public float shootCooldown = 1;
    public float strength = 100;
    public bool corrutinaIniciada=false;
    public AudioSource audioDisparo;

    void Update () {
        Vector3 origen = transform.position + transform.up * 3f;
        Vector3 direccion =
            (objetivo.transform.position - origen).normalized;
        RaycastHit hitInfo;
        if ( Physics.Raycast(origen, direccion, out  hitInfo ))
        {
           string nombre= hitInfo.collider.tag;
           if (nombre=="Player")
           {
                gameObject.GetComponent<Perseguidor>().enabled = true;
                if (!corrutinaIniciada)
                {
                 StartCoroutine("FuegoTiger");
                 corrutinaIniciada=true;
                }
           }
           else
           {
               //StopCoroutine("FuegoTiger");
           }

        }

        Debug.DrawRay(origen, direccion * 100, Color.red);
    }
     IEnumerator FuegoTiger()
        {
           // int value = 0;
            while (true)
            {
                if (GetComponent<MuerteTanque>().enabled)
                {
                    StopCoroutine("FuegoTiger");
                }
                else
                {
                 Shoot(); 
                }
                yield return new WaitForSeconds(5);
            }
        }
          public void Shoot () {
        GameObject createdBullet = Instantiate(bullet);
        createdBullet.transform.position = cannonPivotBone.transform.position;
        Rigidbody body = createdBullet.GetComponent<Rigidbody>();
        body.AddForce(cannonPivotBone.transform.forward * strength,
                      ForceMode.Impulse);
                      audioDisparo.Play();
    }
    
}
