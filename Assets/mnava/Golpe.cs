using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    public Transform enemigo;
    public int daño;
    Vida miVida;
    // Start is called before the first frame update
    void Start()
    {
        miVida=enemigo.GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) 
     {
        if (other.tag=="Filo")
        {
            miVida.bajarVida(daño);
        }
         if (other.tag=="FiloLanza")
        {
            miVida.bajarVida(daño);
            Transform fil=other.transform;
            Transform cubo=fil.parent;
            Transform ce=cubo.parent;
            Transform lanza=ce.parent;
            Rigidbody lanzaCuerpo=lanza.GetComponent<Rigidbody>();
            lanzaCuerpo.isKinematic=false;
        }

     }
}
