using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarArma : MonoBehaviour
{
    public ArradarArma balaMunicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
             Debug.Log("Entro al trigger de cragador");
           
        if(other.tag == "Cargador"){
            if(balaMunicion.estaAgarrando==true){
                Debug.Log("Entro al metodo");
               Destroy(other.gameObject);
                 balaMunicion.cantidadMuniciones = 10;
            }
         

        }
    }
}
