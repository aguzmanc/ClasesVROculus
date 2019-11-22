using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcoMN : MonoBehaviour
{
   
    public Renderer red;
    Rigidbody cuerpo;
    GameObject cuerdaAgarrador;
    Rigidbody body;
    public Material Magarrado;
    public Material Msuelto;
     public Material Mtocado;
    // Start is called before the first frame update
    void Start()
    {
       
       
         cuerpo=GetComponent<Rigidbody>();
         cuerdaAgarrador=transform.Find("cuerda").gameObject;
         cuerdaAgarrador.SetActive(false);
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
      public void agarrar(Transform mano)
    {
        
        red.material=Magarrado;
      
        transform.parent=mano;
        cuerpo.isKinematic=true;

        transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
         cuerdaAgarrador.SetActive(true);
    }   
     public void soltar()
    {
       
            red.material=Msuelto;
      
       
        transform.parent=null;
        cuerpo.isKinematic=false;
        cuerdaAgarrador.SetActive(false);
    }
}
