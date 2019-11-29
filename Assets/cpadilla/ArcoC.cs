using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoC : MonoBehaviour
{
    public Renderer rend;

    public GameObject cuerda;

    Rigidbody body;
    public Material MaterialTocado;
    public Material materialAgarrad;
    public Material materialSuelt;
    void Start()
    {
        body = GetComponent<Rigidbody>();
       
        rend.material = materialSuelt;

        cuerda = transform.Find("pivot").gameObject;
        cuerda.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
      public void Soltar()
    {
        rend.material = materialSuelt;
    }

       public void Agarrar(Transform agarrador)
    {
        rend.material = materialAgarrad;
        body.isKinematic=true;


        transform.parent = agarrador;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        cuerda.SetActive(true);
    }

    public void Tocar()
    {
            rend.material = MaterialTocado;
    }


    //deja caer objeto 
    public void Soltar2()
    {
        transform.parent =null;
        rend.material = MaterialTocado;
        body.isKinematic = false;
        
        cuerda.SetActive(false);
    }

}
