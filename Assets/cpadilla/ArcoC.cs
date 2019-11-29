using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoC : MonoBehaviour
{
    public Renderer red;
    Rigidbody cuerpo;
    public GameObject cuerdaAgarrador;
    Rigidbody body;
    public Material MaterialTocado;
    public Material materialAgarrad;
    public Material materialSuelt;
    void Start()
    {
       
       
         cuerpo=GetComponent<Rigidbody>();
         cuerdaAgarrador.SetActive(false);
        red.material=materialSuelt;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tocar()
    {
      
            red.material=MaterialTocado;
       
    }
    public void dejarTocar()
    {
            red.material=materialSuelt;
       
    }
      public void agarrar(Transform mano)
    {
        
        red.material=materialAgarrad;
      
        transform.parent=mano;
        cuerpo.isKinematic=true;

        transform.localPosition = Vector3.zero;
        transform.localRotation =Quaternion.identity;
        cuerdaAgarrador.SetActive(true);
    }   
     public void soltar()
    {
       
            red.material=materialSuelt;
      
       
        transform.parent=null;
        cuerpo.isKinematic=false;
        cuerdaAgarrador.SetActive(false);
    }
}
