using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaBallesta : MonoBehaviour
{  public GameObject flechaProyectil;
    public GameObject flechaInstaciado;
    
      public Renderer rend;
      public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSoltado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void Tocar(){
        rend.material = materialTocado;
        Debug.Log("toco");
    }
    public void DejarTocar(){
        rend.material = materialSoltado;
    }
    public void Agarrar(){
        rend.material = materialAgarrado;
      //  body.isKinematic=true;
       
        //transform.localPosition=Vector3.zero;
       // transform.localRotation = Quaternion.identity;
    }
    public void Soltar(){
      
        rend.material =materialTocado;
      //  body.isKinematic =false;
    }
         public Rigidbody proyectil(){
         Debug.Log("entro");
       flechaInstaciado = Instantiate(flechaProyectil);
      
        
        flechaInstaciado.transform.localScale = Vector3.one;
          flechaInstaciado.transform.parent = transform;
          flechaInstaciado.transform.localPosition = Vector3.zero;
        flechaInstaciado.transform.Rotate(new Vector3(0f,-180f,0f));
        return flechaInstaciado.GetComponentInChildren<Rigidbody>();
    }
}
