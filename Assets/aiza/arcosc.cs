using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcosc : MonoBehaviour
{
    Renderer rend;

    Rigidbody body;
    public Material MaterialTocado;
    public Material materialAgarrad;
    public Material materialSuelt;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material = materialSuelt;
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
    }

    private void OnTriggerEnter(Collider other) {
        
    }
}
