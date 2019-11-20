using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public Renderer rend;
    Rigidbody body;


    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto;

[Header("Flecha")]
    public GameObject prfabFlecha;
    public float speed;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend.material = materialSuelto;
    }

    private void Update() {
        if(Input.GetButtonUp("Fire1")){
            DisparaFlecha();
        }
    }



    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public void  DisparaFlecha()
    {
        GameObject f = Instantiate(prfabFlecha,transform.position,transform.rotation);
        f.GetComponent<Rigidbody>().AddForce(transform.forward*speed);
        Destroy(f,3);
    }


    public void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }


    public void Soltar() {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }


}
