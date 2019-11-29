using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoBallesta : MonoBehaviour
{
   public AgarradorBallestaW manoIzquierda;
   public AgarradorCulataBallesta manoDerecha;
   public Transform rotar;
Vector3 direccion;
    Quaternion rotacion;

    float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if(manoIzquierda.agarradoIzquierda ==true && manoDerecha.agarradoDerecha ==true){
            direccion = manoDerecha.transform.position - manoIzquierda.transform.position;
            rotacion = Quaternion.LookRotation(direccion);
            rotar.rotation = Quaternion.Slerp(rotar.rotation,rotacion,velocidad * Time.deltaTime);
        }
    }

}
