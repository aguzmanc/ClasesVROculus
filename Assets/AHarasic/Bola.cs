using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{

    public Material materialAgarrado;
    public Material materialSuelto;
    public Material materialTocado;

    Rigidbody body;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody>();
       // rend = GetComponent<Renderer>();??
        rend.material=materialSuelto;
        //cuerda= transform.Find("pivot").gameObject;
        //cuerda.SetActive(false);
    }

    // Update is called once per frame



    public void Tocar(){
        rend.material=materialTocado;
        
    }

    public void DejarDeTocar()
    {
        rend.material=materialSuelto;
    }

    public void Agarrar(Transform agarrador)
    {
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
       // cuerda.SetActive(true);
        //Debug.Log("SIUUU");
    
    }


            public void Soltar()
            {
            transform.parent=null;
            rend.material=materialTocado;
            body.isKinematic=false;
            //gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 1);   
                    
           // cuerda.SetActive(false);
            //Debug.Log("DISPARO!");
            }

            public void Impulso(Vector3 v3)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(v3);
            }
    void Update()
    {
        
    }
}
