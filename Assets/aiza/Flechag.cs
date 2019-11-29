using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flechag : MonoBehaviour
{
    public GameObject pivote;
    public GameObject flecha;

    public float shootcooldown = 1;
    public float fuerza = 220;

    public float velocidadInclinacion = 180;
    public float velocidadDireccion = 360;

    float _timelastshot = 0;

    public bool disparar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot()
    {
        GameObject crearFlecha = Instantiate(flecha,transform.position,transform.rotation);
        crearFlecha.transform.position = pivote.transform.position;
        Rigidbody body = crearFlecha.GetComponent<Rigidbody>();
        body.AddForce(pivote.transform.forward*fuerza,ForceMode.Impulse);
    }

    public void UpdatePlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
        //transform.Rotate(0,velocidadDireccion*Time.deltaTime*Input.GetAxis("Horizontal"),0);
        //pivote.transform.Rotate(velocidadInclinacion*Time.deltaTime * Input.GetAxis("Vertical")*-1,0,0);
     }
    void Update()
    {
        
                if (shootcooldown < 0)
                {
                    UpdatePlayerControl();
                    return; 
                }
                _timelastshot += Time.deltaTime;
                if (_timelastshot > shootcooldown )
                {
                     _timelastshot = 0;
                    if (disparar)
                    {
                         Shoot();
                    }
                   
                   
                }
        
       
    }
}
