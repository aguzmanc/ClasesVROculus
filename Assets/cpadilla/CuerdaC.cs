using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaC : MonoBehaviour
{
    public Renderer rend;
    Rigidbody cuerpo;
    Rigidbody body;
    public Material materialSuelto;
    public Material materialTocado;
    public Material materialAgarrando;

    // Start is called before the first frame update
    void Start()
    {
        cuerpo=GetComponent<Rigidbody>();
        
        rend.material=materialSuelto;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tocar()
    {
      
            rend.material=materialTocado;
       
    }
    public void dejarTocar()
    {
            rend.material=materialSuelto;
       
    }
      public void agarrar()
    {
        
        rend.material=materialAgarrando;
      
       
         
    }   
     public void soltar()
    {
       
            rend.material=materialSuelto;    
    }
}
