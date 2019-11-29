using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoporteBallesta : MonoBehaviour
{
       public Renderer red;
    Rigidbody cuerpo;
    public Material Magarrado;
    public Material Msuelto;
     public Material Mtocado;
     
   public Transform eje;
    
    

    // Start is called before the first frame update
    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        red.material=Msuelto;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void tocar()
    {
      
            red.material=Mtocado;
       
    }
    public void soltar()
    {
      
          red.material=Msuelto;
       
    }
    public void dejarTocar()
    {
            red.material=Msuelto;
       
    }
     public void rotar(Transform ejeMano,Transform manodercha)
    {

            eje.rotation=Quaternion.LookRotation(ejeMano.position-manodercha.position);

       
    }
      public void agarrar(Transform mano)
    {
        
        red.material=Magarrado;
      
      
    }   
    
   
}
