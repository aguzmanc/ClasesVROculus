using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballesta : MonoBehaviour
{
    [Header("Ballesta")]
    public Renderer rend;
    public Renderer rend2;
    Rigidbody body;

    public Material materialTocado;
    Material materialAgarrado;
    public Material materialSuelto;

    Material materialAgarrado2;


    Transform rotador;


    [Header("Flecha")]
    public GameObject prfabFlecha;

    public Transform disparador;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        materialAgarrado = rend.material;
        materialAgarrado2=rend2.material;
        rotador=null;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotador!=null){
            transform.LookAt(rotador);
        }
    }

    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Agarrar2(Transform agarrador) { 
        rend2.material = materialAgarrado;
        rotador=agarrador;

    }

    public void Soltar2() 
    {
        
        rend2.material = materialTocado;
        rotador=null;
    }

    public void Tocar2() {
        rend2.material = materialTocado;
    }


    public void DejarDeTocar2() {
        rend2.material = materialSuelto;
    }

    public void DisparaFlecha(float speed)
    {
        GameObject f = Instantiate(prfabFlecha,disparador.position,disparador.rotation);
        f.GetComponent<Rigidbody>().AddForce(disparador.transform.forward*speed);
        Destroy(f,3);
    }
    public void Soltar() 
    {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }

}
