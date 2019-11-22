using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuerdaFisica : MonoBehaviour
{
    public Renderer red;
    Rigidbody cuerpo;

    Rigidbody body;
    public Material Magarrado;
    public Material Msuelto;
     public Material Mtocado;
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
    public void dejarTocar()
    {
            red.material=Msuelto;
       
    }
      public void agarrar()
    {
        
        red.material=Magarrado;
      
       
         
    }   
     public void soltar()
    {
       
            red.material=Msuelto;    
    }
}
